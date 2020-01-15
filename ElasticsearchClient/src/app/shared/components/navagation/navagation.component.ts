import { Component, OnInit, OnDestroy } from '@angular/core';
import { AuthHelper } from '../../helpers/auth-helper';
import { ManagmentHelper } from '../../helpers/managment-helper';
import { Page } from '../../enums';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-navagation',
  templateUrl: './navagation.component.html',
  styleUrls: ['./navagation.component.css']
})
export class NavagationComponent implements OnInit, OnDestroy {
  screenSubscribtion: Subscription;
  screan: Page;

  constructor(
    private authHelper: AuthHelper,
    private managmentHelper: ManagmentHelper
  ) {
    this.getScreanType();
  }

  ngOnInit() {
  }

  ngOnDestroy(): void {
    this.screenSubscribtion.unsubscribe();
  }

  private getScreanType(): void {
    this.screenSubscribtion = this.managmentHelper.getScreenType().subscribe((data) => {
      this.screan = data;
    });
  }

  logout(): void {
    this.authHelper.logout();
  }

}
