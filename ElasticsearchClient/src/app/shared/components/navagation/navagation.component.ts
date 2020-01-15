import { Component, OnInit } from '@angular/core';
import { AuthHelper } from '../../helpers/auth-helper';
import { ManagmentHelper } from '../../helpers/managment-helper';
import { Page } from '../../enums';

@Component({
  selector: 'app-navagation',
  templateUrl: './navagation.component.html',
  styleUrls: ['./navagation.component.css']
})
export class NavagationComponent implements OnInit {
  screan: Page;
  constructor(
    private authHelper: AuthHelper,
    private managmentHelper: ManagmentHelper
  ) {
    this.getScreanType();
  }

  ngOnInit() {
  }

  private getScreanType(): void {
    this.managmentHelper.getScreenType().subscribe((data) => {
      this.screan = data;
    });
  }

  logout(): void {
    this.authHelper.logout();
  }

}
