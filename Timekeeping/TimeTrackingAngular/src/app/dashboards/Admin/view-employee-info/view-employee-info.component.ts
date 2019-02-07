import { Component, OnInit } from '@angular/core';
import { DateAdapter, MatDialogRef, MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormBuilder, Validators,FormControl} from '@angular/forms';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { EmployeeService } from '../../../../services/employee.service';
import { Employee } from '../../../../domain/employee';
import { ActivatedRoute } from '@angular/router';
import { CancelDialogComponent } from '../../../shared/dialog/cancel-dialog/cancel-dialog.component';
import { UpdateSaveDialogComponent } from './update-save-dialog/update-save-dialog.component';

@Component({
  selector: 'app-view-employee-info',
  templateUrl: './view-employee-info.component.html',
  styleUrls: ['./view-employee-info.component.scss'],
  providers: [EmployeeService, DatePipe]
})
export class ViewEmployeeInfoComponent implements OnInit {
  today: number = Date.now();
  lastName: any;
  employeeFormGroup: FormGroup;
  isAddEmployee: boolean;
  birthdate: Date;
  hiredDate: Date;
  separatedDate: Date;
  maxDate = new Date(Date.now());
  selectEmployee: Employee = {} as Employee;
  employeeList: Employee[];
  indexOfEmployee: number = 0;
  firstName: FormControl;
  tmpRoleID;
  genders: string[] = ['Male', 'Female'];
  employeeStatus: string[] = ['Probationary', 'Regular', 'Contractual', 'Consultant', 'Seasonal', 
                              'Project-based', 'Casual'];
  department: string [] = ['Operations', 'Human Resources', 'Project Management', 'Others'];
  activityType: string [] = ['ABC - OPD', 'DEF - PMO', 'GHI - HR', 'JKL - Others'];
  shifts: string [] = ['Regular Shift', 'Mid Shift', 'Night Shift', 'Custom Shift - Project 1', 
                       'Custom Shift - Project 2', 'Custom Shift - Operations'];
  // dialogRef: MatDialogRef<SaveDialogComponent>;
  message = new FormControl('', [Validators.required]);
  isEditEmployee: boolean;
  // isVisible: boolean = true;

  empID:number;
  constructor(private employeeService: EmployeeService, private fb: FormBuilder,
              private route: ActivatedRoute, public dialog: MatDialog, private datePipe: DatePipe) { }

  ngOnInit() {
    this.employeeFormGroup = this.fb.group({    
    lastName: ['', Validators.required],
    firstName: ['', Validators.required],
    middleName: '',
    gender: ['', Validators.required],
    birthdate: ['', Validators.required],
    hiredDate: ['', Validators.required],
    employeeID: ['', Validators.required],
    employeeStatus: ['', Validators.required],
    position: ['', Validators.required],
    department: ['', Validators.required],
    project: [''],
    activityType: ['', Validators.required],
    separatedDate: [''],
    shift: ['', Validators.required],
    ssSno: ['', Validators.required],
    phiCno: ['', Validators.required],
    tiNno: ['', Validators.required],
    hdmFno: ['', Validators.required]
  });
  const id = +this.route.snapshot.paramMap.get('id');
  this.getEmployee(id);
  this.employeeFormGroup.disable();
  // this.populate();
}
initForm(){
  this.employeeFormGroup = this.fb.group({
    lastName: [this.selectEmployee.lastName, Validators.required],
    firstName: [this.selectEmployee.firstName, Validators.required],
    middleName: [this.selectEmployee.middleName,Validators.required],
    gender: [this.selectEmployee.gender, Validators.required],
    birthdate: [this.selectEmployee.birthdate, Validators.required],
    hiredDate: [this.selectEmployee.hiredDate, Validators.required],
    employeeID: [this.selectEmployee.employeeID, Validators.required],
    employeeStatus: [this.selectEmployee.employeeStatus, Validators.required],
    position: [this.selectEmployee.position, Validators.required],
    department: [this.selectEmployee.department, Validators.required],
    project: [''],
    activityType: [this.selectEmployee.activityType, Validators.required],
    separatedDate: [''],
    shift: [this.selectEmployee.shift, Validators.required],
    ssSno: [this.selectEmployee.ssSno, Validators.required],
    phiCno: [this.selectEmployee.phiCno, Validators.required],
    tiNno: [this.selectEmployee.tiNno, Validators.required],
    hdmFno: [this.selectEmployee.hdmFno, Validators.required]
  })
}

populate():void{
  console.log
  this.employeeFormGroup.setValue({
    lastName: '',
    firstName: '',
    middleName: '',
    gender: '',
    birthdate: '',
    hiredDate: '',
    employeeID: '',
    employeeStatus: '',
    position: '',
    department: '',
    project: '',
    activityType: '',
    separatedDate: '',
    shift: '',
    ssSno: '',
    phiCno: '',
    tiNno: '',
    hdmFno: '' 
  })
}

getEmployee(id){
  this.employeeService.getEmployeeInfo(id).then(
    x => {
      this.tmpRoleID = x.roleID;
      this.employeeFormGroup.setValue({
        lastName: x.lastName,
        firstName: x.firstName,
        middleName: x.middleName,
        gender: x.gender,
        birthdate: x.birthdate,
        hiredDate: x.hiredDate,
        employeeID: x.employeeID,
        employeeStatus: x.employeeStatus,
        position: x.position,
        department: x.department,
        project: x.project,
        activityType: x.activityType,
        separatedDate: x.separatedDate,
        shift: x.shift,
        ssSno: x.ssSno,
        phiCno: x.phiCno,
        tiNno: x.tiNno,
        hdmFno: x.hdmFno
      })
    }
  )
}

loadAllEmployees() {
  this.employeeService.getEmployee().then(result => {
    this.employeeList = result;
  });
}

editEmployee(Employee) {
  this.employeeFormGroup.enable();
  this.selectEmployee = Employee;
  this.selectEmployee = Object.assign({}, this.selectEmployee);
  this.birthdate = new Date(this.selectEmployee.birthdate);
  this.hiredDate = new Date(this.selectEmployee.hiredDate);
  this.separatedDate = new Date(this.selectEmployee.separatedDate);
}

saveEmployee() {
  console.log('works')
  let tmpEmployeeList = [...this.employeeList];
  this.employeeService.editEmployee(this.selectEmployee.employeeID,
    this.selectEmployee).then(result => {
      result.birthdate =
        this.datePipe.transform(this.birthdate, 'yyyy-MM-dd');
      result.hiredDate =
        this.datePipe.transform(this.hiredDate, 'yyyy-MM-dd');
      result.separatedDate =
        this.datePipe.transform(this.separatedDate, 'yyyy-MM-dd');    
       tmpEmployeeList.push(result);
	     tmpEmployeeList[this.indexOfEmployee] = result;
      this.employeeList = tmpEmployeeList;
      this.selectEmployee = null;
    });
  }
  
getErrorMessage() {
  return this.message.hasError('required') ? 'This field is required' : '';
}

cancelEmployee() {
  this.selectEmployee = null;
  this.dialog.open(CancelDialogComponent, {
    height: '10vw', 
    width: '30vw',

  });
}

// updatesaveDialog() {
//   this.dialog.open(UpdateSaveDialogComponent, {
//     height: '10vw', 
//     width: '40vw'
//   });
//   this.loadAllEmployees();
// }

updateEmployee(selectedEmployee:Employee){
  selectedEmployee.roleID = this.tmpRoleID;
  this.employeeService.editEmployee(selectedEmployee.employeeID, selectedEmployee).then();
  this.dialog.open(UpdateSaveDialogComponent, {
    height: '10vw', 
    width: '40vw'
  });
}

}