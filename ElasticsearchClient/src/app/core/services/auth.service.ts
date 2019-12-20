import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RequestGetAuthenticationView, ResponseGenerateJwtTokensView } from 'src/app/shared/models';
import { environment } from 'src/environments/environment.prod';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient,
  ) { }

  signIn(request: RequestGetAuthenticationView): Observable<ResponseGenerateJwtTokensView> {
    return this.http.post<ResponseGenerateJwtTokensView>(environment.apiUrl + 'authentication/login', request);
  }
}
