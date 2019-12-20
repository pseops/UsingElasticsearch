import { Routes, RouterModule } from '@angular/router';
import { SignInComponent } from './sign-in/sign-in.component';

const routes: Routes = [
  { path: 'signIn', component: SignInComponent },
];

export const AuthenticationRoutes = RouterModule.forChild(routes);
