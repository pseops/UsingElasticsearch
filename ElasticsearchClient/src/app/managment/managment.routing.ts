import { Routes, RouterModule } from '@angular/router';
import { MainScreenComponent } from './main-screen/main-screen.component';
import { AdminScreenComponent } from './admin-screen/admin-screen.component';
import { AuthGuard } from '../shared/helpers/auth.guard';
import { UserRole } from '../shared/enums';

const routes: Routes = [
  {path: '', component: MainScreenComponent},
  {path: 'mainScreen', component: MainScreenComponent, canActivate: [AuthGuard]},
  {path: 'adminScreen', component: AdminScreenComponent, canActivate: [AuthGuard], data: { role: UserRole[UserRole.Admin] }},
];

export const ManagmentRoutes = RouterModule.forChild(routes);
