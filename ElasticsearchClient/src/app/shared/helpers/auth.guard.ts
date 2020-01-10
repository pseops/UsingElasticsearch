import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { AuthHelper } from './auth-helper';



@Injectable()
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    private authHelper: AuthHelper) { }

  async canActivate(route: ActivatedRouteSnapshot) {
    const isAuthenticated: boolean = await this.authHelper.isAuthenticated().then(res => res);
    if (isAuthenticated) {
      if (!this.isRolesMatched(route)) {
        return false;
      }
      return true;
    }
    this.router.navigate(['auth', 'login'], { replaceUrl: true });
    return false;
  }

  private isRolesMatched(route: ActivatedRouteSnapshot): boolean {
    const currentRole: string = this.authHelper.getRoleFromToken();
    if (!route.data.role) {
      return true;
    }
    if (route.data.role.toLowerCase() === currentRole.toLowerCase()) {
      return true;
    }
    return false;
  }
}
