import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource } from '@angular/material';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray } from '@angular/forms';
import { CustomValidators } from 'ng2-validation';

import { map } from 'rxjs/operators';
import { ManageLeavesService } from '../../../services/manage-leaves.service';
import { ManageLeaves } from '../../../domain/manage-leaves';



@Component({
  selector: 'app-add-new-leaves',
  templateUrl: './add-new-leaves.component.html',
  styleUrls: ['./add-new-leaves.component.scss'],
  providers: [ManageLeavesService]
})
export class AddNewLeavesComponent implements OnInit {
  manageLeavesForm: FormGroup;
  // eligible: string[] = ['Regular Employee', 'Contractuals < 1 year', 'Contractuals > 1 year', 'Trainees'];

  updatedEvery: string[] = ['1st', '2nd', '3rd', '4th', '5th', '6th', '7th', '8th', '9th', '10th',
    '11th', '12th', '13th', '14th', '15th', '16th', '17th', '18th', '19th', '20th',
    '21st', '22nd', '23rd', '24th', '25th', '26th', '27th', '28th', '29th', '30th', '31st'];
  manageLeavesList: ManageLeaves[];
  selectManageLeaves: ManageLeaves = {} as ManageLeaves;
  isAddManageLeaves: boolean;
  indexOfManageLeaves: number = 0;
  isDeleteManageLeaves: boolean;
  gain: number;
  dataSource;
  leaveType: FormControl;
  // eligible = [
  //   {key: 'Regular Employee', text: 'Regular Employee'},
  // ];
  eligible: string;
  // selectedEligibles: string[] = ['Regular Employee',  'Trainees'];



  message = new FormControl('', [Validators.required]);



  constructor(
    public dialogRef: MatDialogRef<AddNewLeavesComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialog: MatDialog, private router: Router,
    private fb: FormBuilder,
    private manageLeavesService: ManageLeavesService,
  ) { }

  checkValue(event: any) {
    console.log(event);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
    this.manageLeavesForm = this.fb.group({
      leaveType: ['', Validators.required],
      updatedEvery: ['', Validators.required],
      gain: ['', Validators.required],
      eligible: ['', Validators.required],

    });

    this.loadAllManageLeaves();
  }

  loadAllManageLeaves() {
    this.manageLeavesService.getManageLeaves().then(manageLeaves => {
      this.manageLeavesList = manageLeaves;


      this.dataSource = new MatTableDataSource<ManageLeaves>(this.manageLeavesList);
      // this.dataSource.paginator = this.paginator;
    });

  }

  getErrorMessage() {
    return this.message.hasError('required') ? 'This field is required' : '';
  }

  saveManageLeaves() {
    console.log(this.manageLeavesForm.get('eligible').value)
    let tmpManageLeavesList = [...this.manageLeavesList];
    this.manageLeavesService.addManageLeaves(this.selectManageLeaves).then();
    this.loadAllManageLeaves();
  }


}