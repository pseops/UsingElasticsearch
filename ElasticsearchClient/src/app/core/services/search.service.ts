import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { RangeSearchFilterView, WebAppDataView, TermSearchFilterView } from 'src/app/shared/models';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.prod';

@Injectable({
  providedIn: 'root'
})
export class SearchService {


  constructor(
     private http: HttpClient
    ) { }

    rangeSearch(filter: RangeSearchFilterView): Observable<WebAppDataView> {
      return this.http.post<WebAppDataView>(environment.apiUrl + 'data/rangesearch', filter);
    }

    termSearch(filter: TermSearchFilterView): Observable<WebAppDataView> {
      return this.http.post<WebAppDataView>(environment.apiUrl + 'data/termsearch', filter);
    }
}
