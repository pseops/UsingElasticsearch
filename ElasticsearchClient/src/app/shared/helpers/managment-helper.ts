import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Page } from '../enums';

@Injectable({
  providedIn: 'root'
})
export class ManagmentHelper {
  private screenTypeSubject = new BehaviorSubject<Page>(Page.MainScreen);
  constructor() { }

  setScreenType(value: Page): void {
    this.screenTypeSubject.next(value);
  }

  getScreenType(): Observable<Page> {
    return this.screenTypeSubject.asObservable();
  }

}
