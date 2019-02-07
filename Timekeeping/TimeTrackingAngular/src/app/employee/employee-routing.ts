import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeeComponent } from './employee.component';
import { DashboardComponent } from './dashboard/dashboard.component';

export const EmployeeRoutes: Routes = [{
  path: '',
  component: EmployeeComponent,
  children:[
    {
      path: '',
      redirectTo: 'dashboard',
      pathMatch: 'full'
    },
    {
      path: 'dashboard',
      component: DashboardComponent
    }
  ]
}];

