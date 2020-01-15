// import { Injectable } from '@angular/core';
// import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpClient } from '@angular/common/http';
// import { Observable, BehaviorSubject, throwError } from 'rxjs';
// import { catchError, switchMap, filter, take, finalize } from 'rxjs/operators';

// import { AuthHelper } from '../helpers/auth-helper';

// import { ResponseGenerateJwtTokensView } from '../models';
// import { environment } from 'src/environments/environment.prod';

// @Injectable()
// export class Interceptor implements HttpInterceptor {
//   private isRefreshing = false;
//   private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);

//   constructor(
//     private authHelper: AuthHelper,
//     private http: HttpClient,
//   ) { }

//   intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//     if (this.authHelper.getAccessToken()) {

//       request = this.addToken(request, this.authHelper.getAccessToken());
//     }

//     return next.handle(request).pipe(catchError(error => {
//       if (error instanceof HttpErrorResponse && error.status === 401 || error.status === 403) {
//         return this.handle401Error(request, next);
//       }
//       else {
//         return throwError(error);
//       }
//     }));
//   }

//   private handle401Error(request: HttpRequest<any>, next: HttpHandler) {
//     if (!this.isRefreshing) {
//       this.isRefreshing = true;
//       this.refreshTokenSubject.next(null);

//       return this.refresh().pipe(
//         switchMap((user: ResponseGenerateJwtTokensView) => {
//           this.refreshTokenSubject.next(user.accessToken);
//           this.authHelper.login(user);
//           return next.handle(this.addToken(request, user.accessToken));
//         }),
//         finalize(() => {
//           this.isRefreshing = false;
//         }));
//     }
//     return this.refreshTokenSubject.pipe(
//       filter(token => token !== null),
//       take(1),
//       switchMap(jwt => {
//         return next.handle(this.addToken(request, jwt));
//       }));
//   }

//   private addToken(request: HttpRequest<any>, token: string) {
//     return request.clone({
//       setHeaders: {
//         Authorization: `Bearer ${token}`
//       }
//     });
//   }

//   private refresh(): Observable<ResponseGenerateJwtTokensView> {
//     let refreshToken = this.authHelper.getRefreshToken();
//     if (!refreshToken) {
//       this.authHelper.logout();
//       return throwError('');
//     }
//     return this.http.post<ResponseGenerateJwtTokensView>(environment.apiUrl + 'Authentication/refreshtoken', { refreshToken });
//   }
// }

import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse, HttpResponse, HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { Injectable } from '@angular/core';
import { catchError, switchMap, tap } from 'rxjs/operators';
import { AuthHelper } from '../helpers/auth-helper';
import { ResponseGenerateJwtTokensView } from '../models';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class Interceptor implements HttpInterceptor {
  locked = false;

  constructor(
    private authHelper: AuthHelper,
    private http: HttpClient,
  ) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (this.authHelper.getAccessToken()) {
      request = this.addToken(request, this.authHelper.getAccessToken());
    }

    return next.handle(request).pipe(catchError(
      error => {
        if (error instanceof HttpErrorResponse && error.status === 401) {
          if (this.authHelper.getRefreshToken()) {
            return this.handle401Error(request, next);
          }

          this.authHelper.logout();
          return throwError(error);
        }
        return throwError(error);
      }));
  }

  private handle401Error(request: HttpRequest<any>, next: HttpHandler) {
    if (!this.locked) {
      this.locked = true;

      return this.refresh().pipe(
        switchMap((token: any) => {
          token = this.authHelper.getAccessToken();
          this.locked = false;

          return next.handle(this.addToken(request, token));
        })
      );
    }
  }

  private addToken(request: HttpRequest<any>, accessToken: string) {
    return request.clone({
      setHeaders: {
        Authorization: `Bearer ${accessToken}`
      }
    });
  }
  private refresh(): Observable<ResponseGenerateJwtTokensView> {
    let refreshToken = this.authHelper.getRefreshToken();
    if (!refreshToken) {
      this.authHelper.logout();
      return throwError('');
    }
    return this.http.post<ResponseGenerateJwtTokensView>(environment.apiUrl + 'Authentication/refreshtoken', { refreshToken });
  }
}

