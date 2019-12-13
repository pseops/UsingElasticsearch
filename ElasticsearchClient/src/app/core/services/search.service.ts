import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResponseSearchMainScreenView, RequestFiltersMainScreenView, ResponseFiltersMainScreenView } from 'src/app/shared/models';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class SearchService {


  constructor(
     private http: HttpClient
    ) { }

    search(filter: RequestFiltersMainScreenView): Observable<ResponseSearchMainScreenView> {
      return this.http.post<ResponseSearchMainScreenView>(environment.apiUrl + 'data/search', filter);
    }

    getDropDownValues(request: RequestFiltersMainScreenView): Observable<ResponseFiltersMainScreenView> {
      return this.http.post<ResponseFiltersMainScreenView>(environment.apiUrl + 'data/getfilters', request);
    }
}
