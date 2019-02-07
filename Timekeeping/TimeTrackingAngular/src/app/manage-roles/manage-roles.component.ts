import { Component, OnInit, ViewChild } from '@angular/core';
import { Roles } from '../../domain/roles';
import { RoleService } from '../../services/role.service';
import { MatTableDataSource, MatPaginator, MatDialog } from '@angular/material';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';

@Component({
  selector: 'app-manage-roles',
  templateUrl: './manage-roles.component.html',
  styleUrls: ['./manage-roles.component.scss'],
  providers: [RoleService] 
})
export class ManageRolesComponent implements OnInit {
  today: number = Date.now();
  roleList: Roles[];
  selectRoles: Roles;
  dataSource;
  totalRecords: number = 0;
  displayedColumns: string[] = ['roleName', 'actions'];
  indexOfRole: number = 0;
  isDeleteRole: boolean;

  constructor(private roleService: RoleService, private dialog:MatDialog) { }
  @ViewChild(MatPaginator) paginator: MatPaginator;
  ngOnInit() {
    this.loadAllRoles();
  }

  applyFilter(filterValue: string) {
   
    this.dataSource.filter = filterValue.trim().toLowerCase();
  
    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  
  }

  loadAllRoles() {
    this.roleService.getRole().then(roles => {
      this.roleList = roles;
      for (var i = 0; i < this.roleList.length; i++) {
        this.roleList[i].roleName = this.roleList.find(x => x.roleID == this.roleList[i].roleID).roleName;
      }
      this.dataSource = new MatTableDataSource<Roles>(this.roleList);
      this.dataSource.paginator = this.paginator;
    });
    
  }

  deleteRole(Roles) {
  
    this.isDeleteRole = true;
    this.indexOfRole = this.roleList.indexOf(Roles);
    this.selectRoles = Roles;
    console.log(Roles);
    this.selectRoles = Object.assign({}, this.selectRoles);
 
  }

  okDelete(Roles) {
    console.log(Roles);
    
    let tmpRoleList = [...this.roleList];
    this.roleService.deleteRole(Roles.roleID)
        .then(() => {
          tmpRoleList.splice(this.indexOfRole, 1);
          this.roleList = tmpRoleList;
          this.selectRoles = null;
          this.loadAllRoles();
        });
        this.dialog.open(DeleteDialogComponent, {
          height: '10vw', 
          width: '40vw',
        });
        
  }

}