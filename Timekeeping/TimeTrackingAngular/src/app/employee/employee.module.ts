import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutes } from './employee-routing';
import { EmployeeComponent } from './employee.component';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { DemoMaterialModule } from '../demo-material-module';
import { FlexLayoutModule } from '@angular/flex-layout';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(EmployeeRoutes),
    DemoMaterialModule,
    FlexLayoutModule
  ],
  declarations: [EmployeeComponent, DashboardComponent]
})
export class EmployeeModule { }
