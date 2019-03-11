import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-timekeeping',
  templateUrl: './timekeeping.component.html',
  styleUrls: ['./timekeeping.component.scss']
})
export class TimekeepingComponent implements OnInit {
  today: number = Date.now();
  constructor() { }

  ngOnInit() {
  }

}
