import { Component, OnInit, Inject } from '@angular/core';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import { DateAdapter, MatDialogRef, MatDialog, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormBuilder, Validators,FormControl} from '@angular/forms';
import { EmployeeService } from '../../services/employee.service';
import { DatePipe } from '@angular/common';
import { Employee } from '../../domain/employee';
import { Router } from '@angular/router';
import { SaveDialogComponent } from '../new-employee/save-dialog/save-dialog.component';
import { CancelDialogComponent } from '../shared/dialog/cancel-dialog/cancel-dialog.component';

@Component({
  selector: 'app-new-employee',
  templateUrl: './new-employee.component.html',
  styleUrls: ['./new-employee.component.scss'],
  providers: [EmployeeService, DatePipe]
})

export class NewEmployeeComponent implements OnInit {
  lastName: any;
  today: number = Date.now();
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
  genders: string[] = ['Male', 'Female'];
  employeeStatus: string[] = ['Probationary', 'Regular', 'Contractual', 'Consultant', 'Seasonal', 
                              'Project-based', 'Casual'];
  department: string [] = ['Operations', 'Human Resources', 'Project Management', 'Others'];
  costCenter: string [] = ['ABC - OPD', 'DEF - PMO', 'GHI - HR', 'JKL - Others'];
  shifts: string [] = ['Regular Shift', 'Mid Shift', 'Night Shift', 'Custom Shift - Project 1', 
                       'Custom Shift - Project 2', 'Custom Shift - Operations'];
  dialogRef: MatDialogRef<SaveDialogComponent>;
  message = new FormControl('', [Validators.required]);
  
  
  constructor(private employeeService: EmployeeService, private fb: FormBuilder, private datePipe: DatePipe, 
              private adapter: DateAdapter<any>, public dialog: MatDialog, private router: Router) { }

  ngOnInit() {
    this.employeeFormGroup = this.fb.group({    
      lastName: ['', Validators.required],
      firstName: ['', Validators.required],
      middleName: [''],
      gender: ['', Validators.required],
      birthdate: ['', Validators.required],
      hiredDate: ['', Validators.required],
      employeeID: ['', Validators.required],
      employeeStatus: ['', Validators.required],
      position: ['', Validators.required],
      department: ['', Validators.required],
      project: [''],
      costCenter: ['', Validators.required],
      separatedDate: [''],
      shift: ['', Validators.required],
      sssno: ['', Validators.required],
      phicno: ['', Validators.required],
      tinno: ['', Validators.required],
      hdmfno: ['', Validators.required]
    });
}

saveDialog() {
  this.employeeService.addEmployee(this.selectEmployee).then();
  this.dialog.open(SaveDialogComponent, {
    height: '10vw', 
    width: '30vw',
  });
}

// saveEmployee(){
//   this.employeeService.addEmployee(this.selectEmployee).then();
// }

cancelEmployee() {
  this.dialog.open(CancelDialogComponent, {
    height: '10vw', 
    width: '30vw',

  });
}

  getErrorMessage() {
    return this.message.hasError('required') ? 'This field is required' : '';
  }
}
  