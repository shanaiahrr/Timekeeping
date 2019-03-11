import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-save-role-dialog',
  templateUrl: './save-role-dialog.component.html',
  styleUrls: ['./save-role-dialog.component.css']
})
export class SaveRoleDialogComponent implements OnInit {

  constructor(public dialog: MatDialogRef<SaveRoleDialogComponent>) { }

  ngOnInit() {
  }

closeDialog(){
  this.dialog.close();
}
}
