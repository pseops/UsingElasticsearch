import { Component, OnInit } from '@angular/core';
import { ManagmentHelper } from 'src/app/shared/helpers/managment-helper';
import { Page } from 'src/app/shared/enums';
import { AdminScreenService } from 'src/app/core/services/admin-screen.service';
import { ResponseGetUserView } from 'src/app/shared/models/response/response-get-user-view';
import { USERS_COLUMNS, ACTION_COLUMNS } from 'src/app/shared/constants';
import { TableView } from 'src/app/shared/views';
import { UsersPermissionsModel } from 'src/app/shared/models';
import { RequestUpdateUserAdminScreenView } from 'src/app/shared/models/admin-screen/request/request-update-user-admin-screen-view';
import * as _ from 'lodash';

@Component({
  selector: 'app-admin-screen',
  templateUrl: './admin-screen.component.html',
  styleUrls: ['./admin-screen.component.scss']
})
export class AdminScreenComponent implements OnInit {

  responseModel: ResponseGetUserView;

  constructor(
    private managementHelper: ManagmentHelper,
    private adminScreenService: AdminScreenService
  ) {
    this.responseModel = new ResponseGetUserView();

    this.setScreenType();
  }

  ngOnInit() {
    this.getUsers();
  }
  get mainColumns(): Array<TableView> {
    return USERS_COLUMNS;
  }

  get allColumns(): string[] {
    const columns = USERS_COLUMNS.map(m => m.name);
    return columns.concat(this.screens).concat(this.actions);
  }

  get screens(): string[] {
    let keys = Object.keys(Page);
    return keys.slice(keys.length / 2, keys.length);
  }
  get actions(): string[] {
    return ACTION_COLUMNS.map(m => m.name);
  }

  private setScreenType(): void {
    this.managementHelper.setScreenType(Page.AdminScreen);
  }

  getUsers(): void {
    this.adminScreenService.getUsers().subscribe((data) => {
      this.responseModel = data;
    });
  }

  update(element: ResponseGetUserView): void {
    let request = new RequestUpdateUserAdminScreenView();
    request = _.cloneDeep(element);
    this.adminScreenService.updateUser(request).subscribe(res => {
      this.getUsers();
    }
    );
  }

  getPermissions(screen: string, id: string): UsersPermissionsModel {
    return this.responseModel.items.find(data => data.id === id).permissions.find(data => data.page === Page[screen]);
  }
}
