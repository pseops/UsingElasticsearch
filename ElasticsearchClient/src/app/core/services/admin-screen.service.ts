import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseGetUserView } from 'src/app/shared/models/response/response-get-user-view';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RequestCreateUserAdminScreenView } from 'src/app/shared/models/admin-screen/request/request-create-user-admin-screen-view';
import { RequestUpdateUserAdminScreenView } from 'src/app/shared/models/admin-screen/request/request-update-user-admin-screen-view';

@Injectable({
  providedIn: 'root'
})
export class AdminScreenService {

  constructor(
    private http: HttpClient) { }

    getUsers(): Observable<ResponseGetUserView> {
      return this.http.get<ResponseGetUserView>(environment.apiUrl + 'AdminScreen/GetAllUsers');
    }

    createUser(request: RequestCreateUserAdminScreenView) {
      return this.http.post(environment.apiUrl + 'AdminScreen/CreateUser', request);
    }

    updateUser(request: RequestUpdateUserAdminScreenView) {
      return this.http.post(environment.apiUrl + 'AdminScreen/UpdateUser', request);
    }
}
