import { Injectable } from '@angular/core';
// import { CookieService } from 'ngx-cookie-service';
import * as jwt_decode from 'jwt-decode';
// import { LocalStorage } from '@ngx-pwa/local-storage';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/core/services';
import { ResponseGenerateJwtTokensView, RequestGetAuthenticationView, UsersPermissionsModel } from '../models';
import { BehaviorSubject, Subject, Observable } from 'rxjs';
import { Page } from '../enums';

const userId = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier';
const userRole = 'http://schemas.microsoft.com/ws/2008/06/identity/claims/role';
const permissions = 'Permissions';

@Injectable({
  providedIn: 'root'
})
export class AuthHelper {
  public errors: string;
  private userRole$: BehaviorSubject<string>;
  private readonly _userDataKey: string = 'USER_DATA_KEY';
  private _currentUserData: ResponseGenerateJwtTokensView;

  private _serviceMenuState: Subject<any> = new Subject<any>();
  observableMenuState = this._serviceMenuState.asObservable();

  // public cookieChanged: Subject<ResponseGenerateJwtTokensView> = new Subject<ResponseGenerateJwtTokensView>();
  // public logoutEvent: Subject<boolean> = new Subject<boolean>();
  // public loginEvent: Subject<boolean> = new Subject<boolean>();

  constructor(
    private authService: AuthService,
    // private localStorage: LocalStorage,
    private router: Router,
  ) {
    this.userRole$ = new BehaviorSubject('');
    this.initializeUserDate();
    // this.initializeUserDate().subscribe((data: ResponseGenerateJwtTokensView) => {
    //   this._currentUserData = data;
    //   // debugger;
    // });
    // this.initializeUserDate().then((data) => {
    //   this._currentUserData = data;
    // });
  }

  private initializeUserDate(): void {
    this._currentUserData = JSON.parse(localStorage.getItem(this._userDataKey));
  }

  signIn(loginModel: RequestGetAuthenticationView): void {
    this.authService.signIn(loginModel).subscribe(
      (data: ResponseGenerateJwtTokensView) => {
        this.login(data);
        this.router.navigate(['/']);
      });
  }

  login(data: ResponseGenerateJwtTokensView): void {
    // this.localStorage.setItem(this._userDataKey, data).subscribe();
    // this._currentUserData = data;

    // let decode = jwt_decode(data.accessToken);
    // this.localStorage.setItem('userId', decode[userId]).subscribe();
    // this.localStorage.setItem('userFirstName', data.firstName).subscribe();
    // this.localStorage.setItem('userLastName', data.lastName).subscribe();
    // this.localStorage.setItem('userEmail', data.email).subscribe();
    // this.localStorage.setItem('userRole', decode[userRole]).subscribe();
    // this._currentUserData.role = decode[userRole];

    // this.localStorage.setItem('accessToken', data.accessToken).subscribe();
    // this.localStorage.setItem('refreshToken', data.refreshToken).subscribe();
    localStorage.setItem(this._userDataKey, JSON.stringify(data));
    this._currentUserData = data;

    let decode = jwt_decode(data.accessToken);
    this._currentUserData.role = decode[userRole];
    this._currentUserData.permissions = JSON.parse(decode[permissions]);
  }

  getPermissions(screen: Page): UsersPermissionsModel {
    return this._currentUserData.permissions.find(data => data.page === screen);
  }

  private clearStorage(): void {
    // this.localStorage.clear().subscribe();
    localStorage.clear();
    // this.localStorage.removeItem('userId').subscribe();
    // this.localStorage.removeItem('userFirstName').subscribe();
    // this.localStorage.removeItem('userLastName').subscribe();
    // this.localStorage.removeItem('userEmail').subscribe();
    // this.localStorage.removeItem('userRole').subscribe();

    // this.localStorage.removeItem('accessToken').subscribe();
    // this.localStorage.removeItem('refreshToken').subscribe();
  }

  public logout(): void {
    this._currentUserData = null;
    this.clearStorage();
    // this.logoutEvent.next(true);
    this.router.navigate(['/authentication/signIn']);
  }

  public getAccessToken(): string {
    if (this._currentUserData) {
      return this._currentUserData.accessToken;
    }
    return undefined;
  }

  public getRefreshToken(): string {
    if (this._currentUserData) {
      return this._currentUserData.refreshToken;
    }
    return undefined;
  }

  public setTokens(tokens: ResponseGenerateJwtTokensView): void {
    if (this._currentUserData !== null) {
      this._currentUserData.accessToken = tokens.accessToken;
      this._currentUserData.refreshToken = tokens.refreshToken;

      this.login(this._currentUserData);
    }
  }

  isAuthenticated(): boolean {
    // return new Promise((resolve) => {
    //   if (!this._currentUserData) {
    //     this.localStorage.getItem<ResponseGenerateJwtTokensView>(userId).subscribe((data) => {
    //       resolve(!!data);
    //     });
    //   }
    //   else {
    //     resolve(!!this._currentUserData);
    //   }
    // });
    // return new Promise((resolve) => {
    //   if (!this._currentUserData) {
    //     resolve(!!localStorage.getItem(userId));
    //   }
    //   else {
    //     resolve(!!this._currentUserData);
    //   }
    // });
    return this._currentUserData !== null;
  }

  getDecodedAccessToken(token: string): any {

    return jwt_decode(token);
  }

  getUserIdFromToken() {
    const token = this.getAccessToken();
    if (token) {
      return this.getDecodedAccessToken(token).id;
    }
    return null;
  }

  getUserNameFromToken() {
    const userName = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name';
    const token = this.getAccessToken();
    let tokenData = jwt_decode(token);
    return tokenData[userName];

  }

  getRoleFromToken(): string {
    const token = this.getAccessToken();

    let tokenData = jwt_decode(token);
    return tokenData[userRole];
  }

}
