import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatTableDataSource } from '@angular/material';
import { AddNewLeavesComponent } from './add-new-leaves/add-new-leaves.component';

import { DatePipe } from '@angular/common';
import { ManageLeavesService } from '../../services/manage-leaves.service';
import { ManageLeaves } from '../../domain/manage-leaves';
import { EditLeavesComponent } from './edit-leaves/edit-leaves.component';


@Component({
  selector: 'app-manage-leaves',
  templateUrl: './manage-leaves.component.html',
  styleUrls: ['./manage-leaves.component.scss'],
  providers: [ManageLeavesService, DatePipe]
})
export class ManageLeavesComponent implements OnInit {
  today: number = Date.now();
  displayedColumns = ['leaveType', 'updatedEvery', 'gain', 'eligible', 'action'];
  // dataSource = new MatTableDataSource<ManageLeaves>(ELEMENT_DATA);
  dataSource;
  manageLeavesList: ManageLeaves[];

  checked = false;
  indeterminate = false;
  align = 'start';
  disabled = false;
  labelPosition = false;

  constructor(private manageLeavesService: ManageLeavesService,
    public dialog: MatDialog, private router: Router) { }

  ngOnInit() {

    this.loadAllManageLeaves();
  }

  addDialog(): void {
    
    const dialogRef = this.dialog.open(AddNewLeavesComponent, {
      width: '500px',

    });

    dialogRef.afterClosed().subscribe(result => {
      this.router.navigate(['/dashboards/manage-leaves']);
      this.loadAllManageLeaves();
    });
    


  }

  editDialog(id): void {
    const dialogRef = this.dialog.open(EditLeavesComponent, {
      width: '500px',
    });
    let instance = dialogRef.componentInstance;
    let tmpManageLeavesList = [...this.manageLeavesList];
    instance.manageleavesID = id;
    
    dialogRef.afterClosed().subscribe((result:string) => {
      this.router.navigate(['/dashboards/manage-leaves']);
      this.loadAllManageLeaves();
    });
  }




  loadAllManageLeaves() {
  
    this.manageLeavesService.getManageLeaves().then(manageLeaves => {
      this.manageLeavesList = manageLeaves;
      let tmpManageLeavesList = [...this.manageLeavesList];
      this.dataSource = new MatTableDataSource<ManageLeaves>(this.manageLeavesList);
      // this.dataSource.paginator = this.paginator;
    });
    
  }



}