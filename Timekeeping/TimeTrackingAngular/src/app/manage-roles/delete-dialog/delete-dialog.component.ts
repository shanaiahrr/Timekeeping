import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.css']
})
export class DeleteDialogComponent implements OnInit {
  confirmDelete: boolean=false;


  constructor(public dialog: MatDialogRef<DeleteDialogComponent>) { }

  ngOnInit() {
  }

confirm(){
  this.confirmDelete = !this.confirmDelete
}

closeDialog(){
  this.dialog.close();
}
}

