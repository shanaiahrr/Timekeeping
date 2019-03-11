import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource, MatPaginator } from '@angular/material';
import { AddNewShiftComponent } from './add-new-shift/add-new-shift.component';
import { Shifts } from '../../../domain/shifts';
import { ShiftsService } from '../../../services/shifts.service';
import { DatePipe} from '@angular/common';

@Component({
  selector: 'app-manage-work-shifts',
  templateUrl: './manage-work-shifts.component.html',
  styleUrls: ['./manage-work-shifts.component.scss'],
  providers: [ShiftsService, DatePipe]
})
export class ManageWorkShiftsComponent implements OnInit {
  today: number = Date.now();
  shiftsList: Shifts[];
  selectShifts: Shifts;
  dataSource;
  totalRecords: number = 0;
  displayedColumns: string[] = ['shift_Type', 'start_Time', 'end_Time', 'actions']; 
  indexOfRole: number = 0;

  constructor(private datePipe: DatePipe, public dialog: MatDialog, private router: Router, private shiftsService: ShiftsService) { }

  @ViewChild(MatPaginator) paginator: MatPaginator;
  
  ngOnInit() {
    this.loadAllShifts();
  }

  OpenShiftDialog(): void {
    const dialogRef = this.dialog.open(AddNewShiftComponent, {
      width: '550px',

    });

    dialogRef.afterClosed().subscribe(result => {

    });
  }

  loadAllShifts() {
    this.shiftsService.getShifts().then(shifts => {
      this.shiftsList = shifts;
      for (var i = 0; i < this.shiftsList.length; i++) {
        this.shiftsList[i].shift_Type = 
            this.shiftsList.find(x => x.shiftID == this.shiftsList[i].shiftID).shift_Type;
        this.shiftsList[i].start_Time =
            this.datePipe.transform(this.shiftsList[i].start_Time, 'h:mm a'); 
        this.shiftsList[i].end_Time = 
            this.datePipe.transform(this.shiftsList[i].end_Time, 'h:mm a'); 
      }
      this.dataSource = new MatTableDataSource<Shifts>(this.shiftsList);
      this.dataSource.paginator = this.paginator;
    });
    
  }

}