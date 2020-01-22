import { Component, OnInit } from '@angular/core';
import { ManagmentHelper } from 'src/app/shared/helpers/managment-helper';
import { Page } from 'src/app/shared/enums';

@Component({
  selector: 'app-admin-screen',
  templateUrl: './admin-screen.component.html',
  styleUrls: ['./admin-screen.component.scss']
})
export class AdminScreenComponent implements OnInit {

  constructor(
    private managementHelper: ManagmentHelper,
  ) {

    this.setScreenType();
  }

  ngOnInit() {
  }

  private setScreenType(): void {
    this.managementHelper.setScreenType(Page.AdminScreen);
  }
}
