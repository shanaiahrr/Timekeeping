import { Component, OnInit } from '@angular/core';
import { Roles } from '../../../domain/roles';
import { RoleRights } from '../../../domain/rolerights';
import { Rights } from '../../../domain/rights';
import { FormGroup, FormControl, Validators, FormBuilder, FormArray } from '@angular/forms';
import { MatDialogRef, MatDialog } from '@angular/material';
import { SaveRoleDialogComponent } from '../../role/save-role-dialog/save-role-dialog.component';
import { RightsService } from '../../../services/rights.service';
import { Router, ActivatedRoute } from '@angular/router';
import { RoleService } from '../../../services/role.service';
import { TypeOfRightsService } from '../../../services/typeofrights.service';
import { RoleRightsService } from '../../../services/role_rights.service';

@Component({
  selector: 'app-edit-role',
  templateUrl: './edit-role.component.html',
  styleUrls: ['./edit-role.component.css'],
  providers:[RightsService, TypeOfRightsService, RoleService,  RoleRightsService]
})
export class EditRoleComponent implements OnInit {
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

    const id = this.route.snapshot.paramMap.get('id');
     this.getRoleId(id);
     this.getRoleRightWithRoleId(id);
  }

    populate(): void {

      this.roleForm.setValue({
        roleName: '',
        adminRights: '',
        approverRights: '',
        timekeepingRights: ''
  
      })
    }

    getSelectedRights(){
      this.role_rightService.getRoleRights
    }

    getRoleId(id){
      this.roleService.getRoleID(id).then( x=> {
        console.log(x)
        this.roleForm.setValue({
          roleName: x.roleName   
      })
    })
    }

    getRoleRightWithRoleId(roleId){
      this.role_rightService.getRoleRightWithRoleId(roleId).then(data => {
        console.log(data)
      })
    }
  
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
        const approverid = "8848D082-A455-4871-A123-DAEA1626CFE5";
        const timekeeping = "435849FD-36A4-4532-B115-B64EF1C292C6";
        const adminid = "36D83F11-DDAE-46D9-A1C7-FF706AA17F02";

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
      roleID:'9E974F53-0D60-4D46-BE0E-989D69EA1F14',
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