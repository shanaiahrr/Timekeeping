import { Routes } from '@angular/router';

import { AdminComponent } from './admin/admin.component';
// import { Dashboard2Component } from './dashboard2/dashboard2.component';
import { ManageRolesComponent } from '../manage-roles/manage-roles.component';
import { RoleComponent } from '../role/role.component';
import { NewEmployeeComponent } from '../new-employee/new-employee.component';
import { AssignRolesComponent } from '../assign-roles/assign-roles.component';
import { TimekeepingComponent } from './timekeeping/timekeeping.component';
import { ApplyLeaveComponent } from './apply-leave/apply-leave.component';
import { ManageLeavesComponent } from '../manage-leaves/manage-leaves.component';
import { AddNewLeavesComponent } from '../manage-leaves/add-new-leaves/add-new-leaves.component';
import { ViewEmployeeInfoComponent } from './admin/view-employee-info/view-employee-info.component';
import { ManageWorkShiftsComponent } from './manage-work-shifts/manage-work-shifts.component';
import { EditRoleComponent } from '../role/edit-role/edit-role.component';


export const DashboardsRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path:'admin/:id',
        component: ViewEmployeeInfoComponent
      },
      {
        path: 'admin',
        component: AdminComponent,
      },
      // {
      //   path: 'dashboard2',
      //   component: Dashboard2Component
      // },
      {
        path: 'manage-roles',
        component: ManageRolesComponent
      },
      {
        path: 'role',
        component: RoleComponent
      },
      {
        path: 'new-employee',
        component: NewEmployeeComponent
      },
      {
        path: 'assign-roles',
        component: AssignRolesComponent
      },
      {
        path: 'timekeeping',
        component: TimekeepingComponent
      },
      {
        path: 'apply-leave',
        component: ApplyLeaveComponent
      },
      {
        path: 'manage-leaves',
        component: ManageLeavesComponent
      },
      {
        path: 'add-new-leaves',
        component: AddNewLeavesComponent
      } ,
      {
        path: 'manage-work-shifts',
        component: ManageWorkShiftsComponent
      },
      {
        path: 'role/:id/edit-role',
        component: EditRoleComponent
      }
    ]
  }
];
