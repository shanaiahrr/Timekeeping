import { Component, OnInit, Inject } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource } from '@angular/material';
import { FormBuilder, FormGroup, Validators, FormControl, FormArray } from '@angular/forms';
import { CustomValidators } from 'ng2-validation';
import { Http, Response, Headers } from "@angular/http";
import { ManageLeavesService } from '../../../services/manage-leaves.service';
import { ManageLeaves } from '../../../domain/manage-leaves';


@Component({
  selector: 'app-edit-leaves',
  templateUrl: './edit-leaves.component.html',
  styleUrls: ['./edit-leaves.component.scss'],
  providers: [ManageLeavesService]
})
export class EditLeavesComponent implements OnInit {
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
  isEditManageLeaves: boolean;
  message = new FormControl('', [Validators.required]);
  manageleavesID: number;
  eligible: string;
  // checked = false;
  // indeterminate = false;
  // align = 'start';
  // disabled = false;
  // labelPosition = false;

  constructor(
    public dialogRef: MatDialogRef<EditLeavesComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialog: MatDialog, private router: Router,
    private fb: FormBuilder,
    private manageLeavesService: ManageLeavesService,
    private route: ActivatedRoute,
    private http: Http,
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  ngOnInit() {
    // console.log(this.manageleavesID);
    this.manageLeavesForm = this.fb.group({
      leaveType: ['', Validators.required],
      updatedEvery: ['', Validators.required],
      gain: ['', Validators.required],
      eligible: ['', Validators.required],

    });
    const id =+this.route.snapshot.paramMap.get('id');

    this.getManageLeaves();
    this.manageLeavesForm.disable();

    this.loadAllManageLeaves();
  }

  initForm() {
    this.manageLeavesForm = this.fb.group({
      lastName: [this.selectManageLeaves.leaveType, Validators.required],
      firstName: [this.selectManageLeaves.updatedEvery, Validators.required],
      middleName: [this.selectManageLeaves.gain, Validators.required],
      gender: [this.selectManageLeaves.eligible, Validators.required]
    })
  }

  populate(): void {

    this.manageLeavesForm.setValue({
      leaveType: '',
      updatedEvery: '',
      gain: '',
      eligible: '',

    })
  }

  getManageLeaves() {
    this.manageLeavesService.getManageLeavesInfo(this.manageleavesID).then(
      x => {
        this.manageLeavesForm.setValue({
          leaveType: x.leaveType,
          updatedEvery: x.updatedEvery,
          gain: x.gain,
          eligible: x.eligible

        })
      })

  }


  loadAllManageLeaves() {
    this.manageLeavesService.getManageLeaves().then(manageLeaves => {
      this.manageLeavesList = manageLeaves;
 

      this.dataSource = new MatTableDataSource<ManageLeaves>(this.manageLeavesList);
      // this.dataSource.paginator = this.paginator;
    });
    
  }

  editManageLeaves() {
    this.selectManageLeaves = Object.assign({}, this.selectManageLeaves);
    this.manageLeavesForm.enable();

  }

  getErrorMessage() {
    return this.message.hasError('required') ? 'This field is required' : '';
  }

  saveManageLeaves(leave) {
    let tmpManageLeavesList = [...this.manageLeavesList];
    this.manageLeavesService.editManageLeaves(this.manageleavesID,
      leave).then(result => {     
        tmpManageLeavesList.push(result);
        // tmpManageLeavesList[this.indexOfManageLeaves] = result;
        // this.manageLeavesList = tmpManageLeavesList;
        // this.selectManageLeaves = null;
        // this.loadAllManageLeaves(); 
      }   
      );

  }

  deleteManageLeaves() {
    // this.selectManageLeaves = Object.assign({}, this.selectManageLeaves);

    let tmpManageLeavesList = [...this.manageLeavesList];
    this.manageLeavesService.deleteManageLeaves(this.manageleavesID).then(() => {
      tmpManageLeavesList.pop();
      // tmpManageLeavesList.splice(this.indexOfManageLeaves, 1);
      // this.selectManageLeaves = null;
    }); 
  }

  
  // updateManageLeaves(selectedManageLeaves: ManageLeaves) {
  //   this.manageLeavesService.editManageLeaves(selectedManageLeaves.manageLeavesID, selectedManageLeaves).then();
  // }
}