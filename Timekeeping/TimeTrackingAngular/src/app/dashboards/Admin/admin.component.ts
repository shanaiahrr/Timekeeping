import { Component, AfterViewInit, OnInit, ViewChild, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { ChartType, ChartEvent } from 'ng-chartist/dist/chartist.component';
import { EmployeeService } from '../../../services/employee.service';
import { MatPaginator, MatTableDataSource, MAT_DIALOG_DATA, MatDialogRef, MatDialog } from '@angular/material';
import { Employee } from '../../../domain/employee';
import { RoleService } from '../../../services/role.service';
import { ViewEmployeeInfoComponent } from '../admin/view-employee-info/view-employee-info.component';
import { Roles } from '../../../domain/roles';
declare var require: any;


const data: any = require('./data.json');

@Component({
  selector: 'app-import-masterfile',
  templateUrl: 'import-masterfile.html'
  })

  export class ImportMasterFileComponent {
  constructor(
  public dialogRef: MatDialogRef<ImportMasterFileComponent>,
  private router:Router,
  @Inject(MAT_DIALOG_DATA) public data: any
  ) { }

  onNoClick(): void {
  this.dialogRef.close();
  }
  }
  
@Component({
  selector: 'app-dashboard',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss'],
  providers: [EmployeeService, RoleService] 
  
})
export class AdminComponent implements AfterViewInit, OnInit {
  today: number = Date.now();
  employeeList: Employee[];
  selectEmployee: Employee;
  searchEmployee: string = "";
  roleList: Roles[];
  selectRoles: Roles;
  dataSource;
  totalRecords: number = 0;
  displayedColumns: string[] = ['employeeID', 'firstName', 'lastName', 'roleID'];
  dialogRef: MatDialogRef<ViewEmployeeInfoComponent>;

  ngAfterViewInit() {
    // Sparkline chart
    const sparklineLogin = function() {
      // spark count
      (<any>$('.spark-count')).sparkline(
        [4, 5, 0, 10, 9, 12, 4, 9, 4, 5, 3, 10, 9, 12, 10, 9, 12, 4, 9],
        {
          type: 'bar',
          width: '100%',
          height: '70',
          barWidth: '2',
          resize: true,
          barSpacing: '6',
          barColor: 'rgba(255, 255, 255, 0.3)'
        }
      );
    };
    let sparkResize;
    (<any>$(window)).resize(function(e) {
      clearTimeout(sparkResize);
      sparkResize = setTimeout(sparklineLogin, 500);
    });
    sparklineLogin();
  }

  
  constructor(private router: Router, public dialog: MatDialog, 
              private employeeService: EmployeeService, private roleService: RoleService ) {}
  @ViewChild(MatPaginator) paginator: MatPaginator;

  openDialog(): void {
    const dialogRef = this.dialog.open(ImportMasterFileComponent, {
      width: '500px'
    });

    dialogRef.afterClosed().subscribe(result => {
      
    });
  }

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

  // testshow() {
  //   this.dialog.open(ViewEmployeeInfoComponent, {
  //     maxHeight: '100vw', 
  //     maxWidth: '100vw',
  //     height:'100%',
  //     width:'100%'
  //   });
  // }

  rowClick(id){
    // this.router.navigate(['dashboards/admin/view-employee-info']);
  }
}