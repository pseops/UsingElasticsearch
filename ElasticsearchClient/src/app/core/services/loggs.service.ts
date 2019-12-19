import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RequestGetLoggsView, ResponseGetLoggsView, ResponseGetLoggsViewItem } from 'src/app/shared/models';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class LoggsService {

  constructor(
    private http: HttpClient
   ) { }

   getLoggs(filter: RequestGetLoggsView): Observable<ResponseGetLoggsView> {
     return this.http.post<ResponseGetLoggsView>(environment.apiUrl + 'data/getloggs', filter);
   }
}
