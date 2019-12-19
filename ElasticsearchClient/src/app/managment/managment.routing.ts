import { Routes, RouterModule } from '@angular/router';
import { MainScreenComponent } from './main-screen/main-screen.component';
import { AdminScreenComponent } from './admin-screen/admin-screen.component';

const routes: Routes = [
  {path: '', component: MainScreenComponent},
  {path: 'mainScreen', component: MainScreenComponent},
  {path: 'adminScreen', component: AdminScreenComponent},
];

export const ManagmentRoutes = RouterModule.forChild(routes);
