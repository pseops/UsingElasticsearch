import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'managment',
    pathMatch: 'full'
  },
  {
    path: 'authentication',
    loadChildren: 'src/app/authentication/authentication.module#AuthenticationModule'
  },
  {
    path: 'managment',
    loadChildren: 'src/app/managment/managment.module#ManagmentModule'
  },

  { path: '**', redirectTo: 'managment' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }

