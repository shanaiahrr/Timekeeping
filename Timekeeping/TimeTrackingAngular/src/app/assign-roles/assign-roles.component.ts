import { Component, OnInit, ViewChild } from '@angular/core';
import { Employee } from '../../domain/employee';
import { Roles } from '../../domain/roles';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { EmployeeService } from '../../services/employee.service';
import { RoleService } from '../../services/role.service';

@Component({
  selector: 'app-assign-roles',
  templateUrl: './assign-roles.component.html',
  styleUrls: ['./assign-roles.component.scss'],
  providers: [EmployeeService, RoleService] 
})
export class AssignRolesComponent implements OnInit {
  today: number = Date.now();
  employeeList: Employee[];
  selectEmployee: Employee;
  searchEmployee: string = "";
  roleList: Roles[];
  selectRoles: Roles;
  dataSource;
  totalRecords: number = 0;
  displayedColumns: string[] = ['employeeID', 'firstName', 'lastName', 'role', 'actions'];

  constructor(private employeeService: EmployeeService, private roleService: RoleService ) {}
  @ViewChild(MatPaginator) paginator: MatPaginator;
  ngOnInit() {
    this.loadAllEmployees();
 }

 applyFilter(filterValue: string) {
   
  this.dataSource.filter = filterValue.trim().toLowerCase();

  if (this.dataSource.paginator) {
    this.dataSource.paginator.firstPage();
  }

}

  loadAllEmployees() {
    this.employeeService.getEmployee().then(employees => { 
      this.employeeList = employees;
      this.roleService.getRole().then(roles => {
        this.roleList = roles;
        for (var i = 0; i < this.employeeList.length; i++) {
          this.employeeList[i].roleName = this.roleList.find(x => x.roleID == this.employeeList[i].roleID).roleName;
        }

        });  
        this.dataSource = new MatTableDataSource<Employee>(this.employeeList);
        this.dataSource.paginator = this.paginator;
    });
     
  }

  paginate($event) {
    this.employeeService.getEmployeewithPagination($event.first, $event.rows, this.searchEmployee).then(result => {
      this.totalRecords = result.totalRecords;
      this.employeeList = result.results;
      console.log(this.totalRecords);
    })
  }

  searchEmployees() {
    if (this.searchEmployee.length != 1) {
      this.loadAllEmployees();
    }
  }
}
