import { Routes, RouterModule } from '@angular/router';
import { MainScreenComponent } from './main-screen/main-screen.component';
import { AdminScreenComponent } from './admin-screen/admin-screen.component';
import { AuthGuard } from '../shared/helpers/auth.guard';
import { UserRole } from '../shared/enums';
import { LogScreenComponent } from './log-screen/log-screen.component';

const routes: Routes = [
  {path: '', component: MainScreenComponent},
  {path: 'mainScreen', component: MainScreenComponent, canActivate: [AuthGuard]},
  {path: 'adminScreen', component: AdminScreenComponent, canActivate: [AuthGuard], data: { role: UserRole[UserRole.Admin] }},
  {path: 'logScreen', component: LogScreenComponent, canActivate: [AuthGuard]},
];

export const ManagmentRoutes = RouterModule.forChild(routes);
