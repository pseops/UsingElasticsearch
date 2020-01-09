import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainScreenComponent } from './managment/main-screen/main-screen.component';


const routes: Routes = [
  {path: '', component: MainScreenComponent},
  { path: 'managment', loadChildren: () => import('src/app/managment/managment.module').then(m => m.ManagmentModule)},
  { path: 'authentication', loadChildren: () => import('src/app/authentication/authentication.module').then(m => m.AuthenticationModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

