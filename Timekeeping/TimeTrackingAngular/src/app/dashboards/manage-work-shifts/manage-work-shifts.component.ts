import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AddNewShiftComponent } from './add-new-shift/add-new-shift.component';

@Component({
  selector: 'app-manage-work-shifts',
  templateUrl: './manage-work-shifts.component.html',
  styleUrls: ['./manage-work-shifts.component.scss']
})
export class ManageWorkShiftsComponent implements OnInit {
  today: number = Date.now();

  constructor(public dialog: MatDialog, private router: Router) { }

  
  ngOnInit() {
  }

  OpenShiftDialog(): void {
    const dialogRef = this.dialog.open(AddNewShiftComponent, {
      width: '550px',

    });

    dialogRef.afterClosed().subscribe(result => {

    });
  }

}