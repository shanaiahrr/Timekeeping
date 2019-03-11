import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-update-save-dialog',
  templateUrl: './update-save-dialog.component.html',
  styleUrls: ['./update-save-dialog.component.scss']
})
export class UpdateSaveDialogComponent implements OnInit {
  confirmSave: boolean=false;


  constructor(public dialog: MatDialogRef<UpdateSaveDialogComponent>) { }

  ngOnInit() {
  }

confirm(){
  this.confirmSave = !this.confirmSave
}

closeDialog(){
  this.dialog.close();
}
}
