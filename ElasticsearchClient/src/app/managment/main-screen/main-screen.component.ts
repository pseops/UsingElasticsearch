import { Component, OnInit } from '@angular/core';
import { SearchService } from '../../core/services/search.service';
import {
  ResponseSearchMainScreenView,
  RequestFiltersMainScreenView,
  ResponseFiltersMainScreenView,
  RequestSearchMainScreenView
} from '../../shared/models';
import { NgModel } from '@angular/forms';
import { Sort } from '@angular/material/sort';
import { MatSelectChange } from '@angular/material/select';
import { FilterName } from 'src/app/shared/enums';
import { TableView } from 'src/app/shared/views';
import {
  MAIN_COLUMNS,
  MULTI_SELECT_FILTERS,
  SELECT_FILTERS,
  REPEATED_COLUMNS,
  PREFIX_NAME,
  TOP_HEADERS
} from 'src/app/shared/constants';

@Component({
  selector: 'app-search-filter',
  templateUrl: './main-screen.component.html',
  styleUrls: ['./main-screen.component.css']
})
export class MainScreenComponent implements OnInit {
  responseSearchData: ResponseSearchMainScreenView;
  testColumns: string[];

  requestFilters: RequestFiltersMainScreenView;
  storedFilters: RequestSearchMainScreenView;
  responseDropDown: ResponseFiltersMainScreenView;

  constructor(
    private searchService: SearchService,
  ) {

    this.responseSearchData = new ResponseSearchMainScreenView();
    this.requestFilters = new RequestFiltersMainScreenView();
    this.storedFilters = new RequestSearchMainScreenView();
    this.responseDropDown = new ResponseFiltersMainScreenView();
  }

  ngOnInit() {
    this.search();
  }

  styleLastRepeated(column: string): boolean {
    column = column.substring(3);
    return column === REPEATED_COLUMNS[REPEATED_COLUMNS.length - 1].name;
  }

  styleLastSticky(column: string): boolean {
    return column === MAIN_COLUMNS[MAIN_COLUMNS.length - 1].name;
  }

  get topHeaders(): Array<TableView> {
    return TOP_HEADERS;
  }

  get topHeadersNames(): string[] {
    return TOP_HEADERS.map(z => z.name);
  }

  get multiSelectFilters(): Array<TableView> {
    return MULTI_SELECT_FILTERS;
  }

  get selectFilters(): Array<TableView> {
    return SELECT_FILTERS;
  }

  get mainColumns(): Array<TableView> {
    return MAIN_COLUMNS;
  }

  get allColumns(): string[] {
    const columns = MAIN_COLUMNS.map(m => m.name);
    return columns.concat(this.repeatedColumns.map(m => m.name));
  }

  get repeatedColumns(): Array<TableView> {
    let temp = new Array<TableView>();

    PREFIX_NAME.forEach((prefix) => {
      REPEATED_COLUMNS.forEach((column) => {
        const str = prefix + column.name;
        const view: TableView = { name: str, viewName: column.viewName };
        temp.push(view);
      });
    });
    return temp;
  }

  search(): void {
    this.searchService.search(this.requestFilters).subscribe((data) => {
      this.responseSearchData = data;
    });
  }

  reset(): void {
    this.requestFilters.reset();
    this.storedFilters.reset();
  }

  handlePage(e: any): void {
    this.requestFilters.from = e.pageIndex * e.pageSize;
    this.requestFilters.count = e.pageSize;

    this.search();
  }

  getDropDownValues(currentFilter: string): void {
    this.requestFilters.currentFilter = FilterName[this.firstLetterToUpper(currentFilter)];
    this.searchService.getDropDownValues(this.requestFilters).subscribe(data => {
      this.responseDropDown = data;
      this.storedFilters.filters[currentFilter] = data.items;
    });
  }

  sortData(sort: Sort): void {
    // this.printingEditionFilterModel.SortColumn = SortColumnType[sort.active];
    // this.printingEditionFilterModel.SortType = SortType[sort.direction];

    // this.getPrintingEditions();
  }

  checkBoxEventHandler(event: MatSelectChange, filter: string): void {
    let model = (event.source.ngControl as NgModel).model as Array<string>;

    if (model.length !== 0 && model[0] !== null) {
      this.requestFilters.filters[filter] = this.requestFilters.filters[filter].filter(f => !f.includes(model));
    }
  }

  firstLetterToLower(name: string): string {
    name = name.charAt(0).toLowerCase() + name.substring(1);
    return name;
  }

  firstLetterToUpper(name: string): string {
    name = name.charAt(0).toUpperCase() + name.substring(1);
    return name;
  }

  fromPercent(num: number): number | null {
    return num !== null ? num / 100 : null;
  }

  toPercent(num: number): number | null {
    return num !== null ? num * 100 : null;
  }
}
