import 'hammerjs';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { DemoMaterialModule } from '../demo-material-module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { DashboardsRoutes } from './dashboards.routing';
import { ChartistModule } from 'ng-chartist';
import { ChartsModule } from 'ng2-charts';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AdminComponent, ImportMasterFileComponent } from './admin/admin.component';
import { Dashboard2Component } from './dashboard2/dashboard2.component';
import { ManageRolesComponent } from '../manage-roles/manage-roles.component';
import { RoleComponent } from '../role/role.component';
import { NewEmployeeComponent } from '../new-employee/new-employee.component';
import { AssignRolesComponent } from '../assign-roles/assign-roles.component';
import { SaveDialogComponent } from '../new-employee/save-dialog/save-dialog.component';
import { SharedModule } from '../shared/shared.module';
import { TimekeepingComponent } from './timekeeping/timekeeping.component';
import { ApplyLeaveComponent } from './apply-leave/apply-leave.component';
import { ManageLeavesComponent } from '../manage-leaves/manage-leaves.component';
import { AddNewLeavesComponent } from '../manage-leaves/add-new-leaves/add-new-leaves.component';
import { ViewEmployeeInfoComponent } from './admin/view-employee-info/view-employee-info.component';
import { UpdateSaveDialogComponent } from './admin/view-employee-info/update-save-dialog/update-save-dialog.component';
import { ManageWorkShiftsComponent } from './manage-work-shifts/manage-work-shifts.component';
import { AddNewShiftComponent } from './manage-work-shifts/add-new-shift/add-new-shift.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EditLeavesComponent } from '../manage-leaves/edit-leaves/edit-leaves.component';
import { DeleteDialogComponent } from '../manage-roles/delete-dialog/delete-dialog.component';
import { SaveRoleDialogComponent } from '../role/save-role-dialog/save-role-dialog.component';
import { EditRoleComponent } from '../role/edit-role/edit-role.component';

// CancelDialogComponent, SaveChangesDialogComponent, SaveDialogComponent
@NgModule({
  imports: [
    CommonModule,
    DemoMaterialModule,
    FlexLayoutModule,
    ChartistModule,
    ChartsModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
    RouterModule.forChild(DashboardsRoutes),
    NgbModule
  ],
  providers: [],
  entryComponents: [ImportMasterFileComponent, SaveDialogComponent, ViewEmployeeInfoComponent, 
                    UpdateSaveDialogComponent, AddNewShiftComponent, DeleteDialogComponent, 
                    SaveRoleDialogComponent],
  declarations: [AdminComponent, ImportMasterFileComponent, Dashboard2Component, 
                 ManageRolesComponent, RoleComponent, NewEmployeeComponent, AssignRolesComponent, 
                 SaveDialogComponent, TimekeepingComponent, ApplyLeaveComponent, 
                 ManageLeavesComponent, AddNewLeavesComponent, ViewEmployeeInfoComponent, 
                 UpdateSaveDialogComponent, ManageWorkShiftsComponent, AddNewShiftComponent, 
                 EditLeavesComponent, DeleteDialogComponent, SaveRoleDialogComponent, 
                 EditRoleComponent]
})
export class DashboardsModule {}
