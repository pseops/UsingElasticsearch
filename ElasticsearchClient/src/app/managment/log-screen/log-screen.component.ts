import { Component, OnInit } from '@angular/core';
import { ManagmentHelper } from 'src/app/shared/helpers/managment-helper';
import { LoggsService } from 'src/app/core/services';
import { TableView } from 'src/app/shared/views';
import { LOGGS_COLUMNS } from 'src/app/shared/constants';
import { RequestGetLoggsView, ResponseGetLoggsView } from 'src/app/shared/models';
import { Page } from 'src/app/shared/enums';

@Component({
  selector: 'app-log-screen',
  templateUrl: './log-screen.component.html',
  styleUrls: ['./log-screen.component.scss']
})
export class LogScreenComponent implements OnInit {
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
    this.getLoggs();
  }

  private setScreenType(): void {
    this.managementHelper.setScreenType(Page.LogScreen);
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
