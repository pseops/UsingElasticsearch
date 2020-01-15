import { Component, OnInit } from '@angular/core';
import { LoggsService } from 'src/app/core/services/loggs.service';
import { RequestGetLoggsView, ResponseGetLoggsView } from 'src/app/shared/models';
import { TableView } from 'src/app/shared/views';
import { LOGGS_COLUMNS } from 'src/app/shared/constants';
import { ManagmentHelper } from 'src/app/shared/helpers/managment-helper';
import { Page } from 'src/app/shared/enums';

@Component({
  selector: 'app-admin-screen',
  templateUrl: './admin-screen.component.html',
  styleUrls: ['./admin-screen.component.css']
})
export class AdminScreenComponent implements OnInit {
  filter: RequestGetLoggsView;
  loggsData: ResponseGetLoggsView;

  constructor(
    private managementHelper: ManagmentHelper,
    private loggsService: LoggsService,
  ) {
    this.filter = new RequestGetLoggsView();
    this.loggsData = new ResponseGetLoggsView();

    this.setScreenType();
  }

  ngOnInit() {
    setTimeout(() => {
      this.getLoggs();
    }, 300);
  }

  private setScreenType(): void {
    this.managementHelper.setScreenType(Page.MainScreen);
  }

  get displayedColumns(): TableView[] {
    return LOGGS_COLUMNS;
  }

  get columnsNames(): string[] {
    return LOGGS_COLUMNS.map(m => m.name);
  }

  getLoggs(): void {
    this.loggsService.getLoggs(this.filter).subscribe(data => {
      this.loggsData = data;
    });
  }

  handlePage(e: any): void {
    this.filter.pageNumber = e.pageIndex + 1;
    this.filter.pageSize = e.pageSize;

    this.getLoggs();
  }

}
