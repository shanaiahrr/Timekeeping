import { Component, OnInit } from '@angular/core';
import { Rights } from '../../domain/rights';
import { RightsService } from '../../services/rights.service';
import { TypeOfRightsService } from '../../services/typeofrights.service';
import { FormBuilder, FormGroup, FormArray, FormControl, Validators } from '@angular/forms';
import { RoleService } from '../../services/role.service';
import { RoleRightsService } from '../../services/role_rights.service';
import { Roles } from '../../domain/roles';
import { RoleRights } from '../../domain/rolerights';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialog, MatDialogRef } from '@angular/material';
import { SaveRoleDialogComponent } from './save-role-dialog/save-role-dialog.component';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.scss'],
  providers: [RightsService, TypeOfRightsService, RoleService, RoleRightsService]
})
export class RoleComponent implements OnInit {
  today: number = Date.now();
  checked = false;
  fullaccess = false;
  indeterminate = false;
  timeKeeping = false;
  align = 'start';
  disabled = false;
  labelPosition = false;
  selectRole: Roles = {} as Roles;
  selectRole_Right: RoleRights = {} as RoleRights;
  rightList: Rights[];
  adminRights: Rights[];
  approverRights: Rights[];
  timekeepingRights: Rights[];
  roleForm: FormGroup;
  rolesList: Roles[];
  role_rightsList: RoleRights[];
  message = new FormControl('', [Validators.required]);
  dialogRef: MatDialogRef<SaveRoleDialogComponent>;
  selectedAdminRights
  selectedApproverRights
  selectedTimekeepingRights

  constructor(private rightSerivce: RightsService, private typeOfRightsService: TypeOfRightsService,
              private fb:FormBuilder, private roleService: RoleService, private role_rightService: RoleRightsService,
              private router: Router, public dialog: MatDialog, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getRightsList();
    // console.log(this);

    this.roleForm = this.fb.group({
      roleName: ['', Validators.required],
      adminRights: [],
      approverRights: [],
      timekeepingRights: []     
    })

    // const id =+this.route.snapshot.paramMap.get('id');
    // this.getRoleRightInfo(id);
  }

    // populate(): void {

    //   this.roleForm.setValue({
    //     roleName: '',
    //     adminRights: '',
    //     approverRights: '',
    //     timekeepingRights: ''
  
    //   })
    // }
  
    // getRoleRightInfo(id) {
    //   this.role_rightService.getRoleRightInfo(id).then(
    //     x => {
    //       this.roleForm.setValue({
    //         roleName: x.roleName,
    //         adminRights: this.selectedAdminRights,
    //         approverRights: this.selectedApproverRights,
    //         timekeepingRights: this.selectedTimekeepingRights
    //       })
    //     })
    // }

  getErrorMessage() {
    return this.message.hasError('required') ? 'This field is required' : '';
  }

  getRightsList() {
    this.adminRights = [];
    this.approverRights = [];
    this.timekeepingRights = [];
    this.rightSerivce.getRights().then(rights => {
      // console.log(rights);
      rights.forEach(data => {
        const approverid = "76433C31-7910-4321-B988-8FDFE0E69887";
        const timekeeping = "0573F5C4-2872-419E-8E91-EE0A70ECC18D";
        const adminid = "44EB58F7-7FFC-4043-968F-300942595130";

        if (data.typeID == adminid.toLowerCase()) {
          // console.log("admin");
          this.adminRights.push(data);
        }
        else if (data.typeID == approverid.toLowerCase()) {   
          // console.log("approver");    
          this.approverRights.push(data);
        }
        else if (data.typeID == timekeeping.toLowerCase()) {
          // console.log("timekeeping")
          this.timekeepingRights.push(data);
        }
      })
      // console.log(this.adminRights);
      // console.log(this.approverRights);
      // console.log(this.timekeepingRights);
      const adminControls = this.adminRights.map(x => new FormControl(false))

      const approverControls = this.approverRights.map(x => new FormControl(false));
      
      const timekeepingControls = this.timekeepingRights.map(x => new FormControl(false));
      
      this.roleForm = this.fb.group({
        roleName: ['', Validators.required],
        approverRights: new FormArray(approverControls),
        adminRights: new FormArray(adminControls),
        timekeepingRights: new FormArray(timekeepingControls)
      })
    })
  }

  saveRole(){
    
    let role:Roles = {
      roleID:'03EF0911-7415-4A51-B52C-A63380425630',
      roleName:this.roleForm.controls.roleName.value
    }
    this.roleService.addRole(role).then(x=>console.log(x));
    this.selectedAdminRights = this.roleForm.value.adminRights
      .map((v,x) => v ? this.adminRights[x].rightID : null)
      .filter(v => v !== null);
      // console.log(selectedAdminRights);
   this.selectedApproverRights = this.roleForm.value.approverRights
      .map((v,i) => v ? this.approverRights[i].rightID : null)
      .filter(v => v !== null);
      // console.log(selectedApproverRights);
    this.selectedTimekeepingRights = this.roleForm.value.timekeepingRights
      .map((v,y) => v ? this.timekeepingRights[y].rightID : null)
      .filter(v => v !== null);
     const joined = [...this.selectedAdminRights,...this.selectedApproverRights,...this.selectedTimekeepingRights]
     console.log(joined);
    this.roleService.addRole(role)
     for(var i = 0; i<joined.length; i++){
      this.role_rightService.getRoleRights
     }
     this.dialog.open(SaveRoleDialogComponent, {
      height: '10vw', 
      width: '40vw',
    });
      // console.log(selectedTimekeepingRights);

    // this.router.navigate(['/dashboards/manage-roles']);
  }

}