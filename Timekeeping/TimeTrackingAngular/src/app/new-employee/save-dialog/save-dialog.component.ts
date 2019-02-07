import { Component, OnInit, Input } from '@angular/core';
import { MatDialogRef } from '@angular/material';


@Component({
  selector: 'app-save-dialog',
  templateUrl: './save-dialog.component.html',
  styleUrls: ['./save-dialog.component.css']
})
export class SaveDialogComponent implements OnInit {
confirmSave: boolean=false;


  constructor(public dialog: MatDialogRef<SaveDialogComponent>) { }

  ngOnInit() {
  }

confirm(){
  this.confirmSave = !this.confirmSave
}

closeDialog(){
  this.dialog.close();
}
}
