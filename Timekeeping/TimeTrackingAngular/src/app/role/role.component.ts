import { Component, OnInit } from '@angular/core';
import { Rights } from '../../domain/rights';
import { RightsService } from '../../services/rights.service';
import { TypeOfRightsService } from '../../services/typeofrights.service';
import { FormBuilder, FormGroup, FormArray, FormControl, Validators } from '@angular/forms';
import { RoleService } from '../../services/role.service';
import { RoleRightsService } from '../../services/role_rights.service';
import { Roles } from '../../domain/roles';
import { RoleRights } from '../../domain/rolerights';

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

  constructor(private rightSerivce: RightsService, private typeOfRightsService: TypeOfRightsService,
    private fb:FormBuilder, private roleService: RoleService, private role_rightService: RoleRightsService) { }

  ngOnInit() {
    this.getRightsList();
    // console.log(this);

    this.roleForm = this.fb.group({
      roleName: ['', Validators.required],
      adminRights: [],
      approverRights: [],
      timekeepingRights: []  
    })
  }

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
    
    // console.log(this.roleForm.get('approverRights').value)
    // console.log(this.roleForm.get('adminRights').value)
    // console.log(this.roleForm.get('timekeepingRights').value)
    // let tmpRolesList = [...this.rolesList];
    
    // let tmpRole_RightsList = [...this.role_rightsList];
    let role:Roles = {
      roleID:'F4A8258A-0BE8-479A-992B-165E4A890BD5',
      roleName:this.roleForm.controls.roleName.value

    }
    this.roleService.addRole(role).then(x=>console.log(x));
    const selectedAdminRights = this.roleForm.value.adminRights
      .map((v,x) => v ? this.adminRights[x].rightID : null)
      .filter(v => v !== null);
      // console.log(selectedAdminRights);
    const selectedApproverRights = this.roleForm.value.approverRights
      .map((v,i) => v ? this.approverRights[i].rightID : null)
      .filter(v => v !== null);
      // console.log(selectedApproverRights);
    const selectedTimekeepingRights = this.roleForm.value.timekeepingRights
      .map((v,y) => v ? this.timekeepingRights[y].rightID : null)
      .filter(v => v !== null);
     const joined = [...selectedAdminRights,...selectedApproverRights,...selectedTimekeepingRights]
     console.log(joined)
    this.roleService.addRole()
     for(var i = 0; i<joined.length; i++){
      this.role_rightService.getRoleRights
     }
      // console.log(selectedTimekeepingRights);

    //   this.roleService.addRole(this.selectRole).then(roles => { 
    //     this.rolesList = roles;
    //     this.roleService.getRoleID(id).then(roles => {
    //       this.roleList = roles;
    //       this.role_rightServie.addRoleRight(this.selectRole_Right).then(rolerights => {
    //        const selectedAdminRights = this.roleForm.value.adminRights
    //        .map((v,x) => v ? this.adminRights[x].rightID : null)
    //        .filter(v => v !== null);
    //   // console.log(selectedAdminRights);
    //        const selectedApproverRights = this.roleForm.value.approverRights
    //       .map((v,i) => v ? this.approverRights[i].rightID : null)
    //       .filter(v => v !== null);
    //   // console.log(selectedApproverRights);
    //        const selectedTimekeepingRights = this.roleForm.value.timekeepingRights
    //       .map((v,y) => v ? this.timekeepingRights[y].rightID : null)
    //       .filter(v => v !== null);  
    //       })
    //       for (var i = 0; i < this.employeeList.length; i++) {
    //         this.employeeList[i].roleName = this.roleList.find(x => x.roleID == this.employeeList[i].roleID).roleName;
    //       }

    //       });  
    //       
    //   });
       
    // }
      // this.roleService.addRole(this.selectRole).then();
      // this.roleService.getRoleID(this.selectRole).then();
      // this.role_rightService.addRoleRight(this.selectRole_Right).then();


  }
}