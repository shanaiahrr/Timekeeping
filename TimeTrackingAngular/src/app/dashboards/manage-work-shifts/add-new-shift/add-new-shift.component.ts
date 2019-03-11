import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AmazingTimePickerService } from 'amazing-time-picker';

@Component({
  selector: 'app-add-new-shift',
  templateUrl: './add-new-shift.component.html',
  styleUrls: ['./add-new-shift.component.scss']
})
export class AddNewShiftComponent implements OnInit {
  selectedStartTime: string;
  selectedEndTime: string;

  constructor(
    public dialogRef: MatDialogRef<AddNewShiftComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialog: MatDialog, private router: Router,
    private atp: AmazingTimePickerService
            ) { }

  // time1 = {hour: 7, minute: 30};
  // meridian1 = true;
  // time2 = {hour: 14, minute: 45};
  // meridian2 = true;
  // // toggleMeridian() {
  // //     this.meridian = !this.meridian;
  // // }

  // setMeridian(){
  //   this.meridian1 = true;
  //   this.meridian2 = true;
  // }

  ngOnInit() {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  openStartTime() {
    const amazingTimePicker = this.atp.open({
        theme: 'material-blue',
    });
    amazingTimePicker.afterClose().subscribe(startTime => {
        this.selectedStartTime = startTime;
    });
}

  openEndTime() {
  const amazingTimePicker = this.atp.open({
      theme: 'material-blue',
  });
  amazingTimePicker.afterClose().subscribe(endTime => {
    this.selectedEndTime = endTime;
});
}

 saveShift(){
   
 } 

}