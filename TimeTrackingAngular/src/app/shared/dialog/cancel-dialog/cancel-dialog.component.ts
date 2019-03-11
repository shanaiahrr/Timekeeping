import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cancel-dialog',
  templateUrl: './cancel-dialog.component.html',
  styleUrls: ['./cancel-dialog.component.css']
})
export class CancelDialogComponent implements OnInit {

  constructor( private dialog: MatDialogRef<CancelDialogComponent>, private router:Router) { }

  ngOnInit() {

  }

 confirmCancel(){
  this.dialog.close();
  this.router.navigate(['/dashboards/admin']);
 }

 cancelNo(){
   this.dialog.close();
   
 }

}
