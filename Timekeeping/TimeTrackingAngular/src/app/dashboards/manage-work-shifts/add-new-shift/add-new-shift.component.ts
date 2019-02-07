import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-add-new-shift',
  templateUrl: './add-new-shift.component.html',
  styleUrls: ['./add-new-shift.component.scss']
})
export class AddNewShiftComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<AddNewShiftComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialog: MatDialog, private router: Router
  ) { }

  time = {hour: 7, minute: 30};
  meridian = true;

  // toggleMeridian() {
  //     this.meridian = !this.meridian;
  // }

  setMeridian(){
    this.meridian = true;
  }
  
  onNoClick(): void {
    this.dialogRef.close();
  }


  ngOnInit() {
  }

}