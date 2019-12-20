import { Injectable } from '@angular/core';
// import { CookieService } from 'ngx-cookie-service';
import * as jwt_decode from 'jwt-decode';
import { LocalStorage } from '@ngx-pwa/local-storage';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services';
import { ResponseGenerateJwtTokensView, RequestGetAuthenticationView } from '../models';
import { BehaviorSubject, Observable } from 'rxjs';
import { UserRole } from '../enums';



const userId = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier';
const userRole = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';

@Injectable({
  providedIn: 'root'
})
export class AuthHelper {
  public errors: string;
  private userRole$: BehaviorSubject<string>;

  constructor(
    private authService: AuthService,
    // private cookieService: CookieService,
    private localStorage: LocalStorage,
    private router: Router,
  ) {
    this.userRole$ = new BehaviorSubject('');
  }

  get userRole(): Observable<string>{

  }

  signIn(loginModel: RequestGetAuthenticationView): void {
    this.authService.signIn(loginModel).subscribe(
      (data: ResponseGenerateJwtTokensView) => {
          let decode = jwt_decode(data.accessToken);

          // this.localStorage.setItem('userData', data).subscribe();

          // this.storageService.setUserId(decode[userId]);
          // this.storageService.setUserFirstName(data.firstName.toString());
          // this.storageService.setUserLastName(data.lastName.toString());
          // this.storageService.setUserEmail(data.email.toString());
          // this.storageService.setUserRole(decode[userRole]);

          this.localStorage.setItem('userId', decode[userId]).subscribe();
          this.localStorage.setItem('userFirstName', data.firstName).subscribe();
          this.localStorage.setItem('userLastName', data.lastName).subscribe();
          this.localStorage.setItem('userEmail', data.email).subscribe();
          this.localStorage.setItem('userRole', decode[userRole]).subscribe();

          this.localStorage.setItem('accessToken', data.accessToken).subscribe();
          this.localStorage.setItem('refreshToken', data.refreshToken).subscribe();

          // this.localStorage.getItem('accessToken', { type: 'string' }).subscribe((token: string) => {
          //   { console.log(token); }
          // });
          this.router.navigate(['/printingEdition/printingEditions']);
      });
  }

}
