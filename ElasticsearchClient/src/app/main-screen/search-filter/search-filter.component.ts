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
import { TableConstants, FilterConstants } from 'src/app/shared/constants';
import { MatSelectChange } from '@angular/material/select';
import { FilterName } from 'src/app/shared/enums';

@Component({
  selector: 'app-search-filter',
  templateUrl: './search-filter.component.html',
  styleUrls: ['./search-filter.component.css']
})
export class SearchFilterComponent implements OnInit {
  responseSearchData: ResponseSearchMainScreenView;
  displayedColumns: string[];
  requestFilters: RequestFiltersMainScreenView;
  storedFilters: RequestSearchMainScreenView;
  responseDropDown: ResponseFiltersMainScreenView;
  multiSelectFilters: string[];
  selectFilters: string[];

  constructor(
    private searchService: SearchService,
    private tableConst: TableConstants,
    private filterConst: FilterConstants
  ) {

    this.responseSearchData = new ResponseSearchMainScreenView();
    this.requestFilters = new RequestFiltersMainScreenView();
    this.storedFilters = new RequestSearchMainScreenView();
    this.responseDropDown = new ResponseFiltersMainScreenView();


    this.multiSelectFilters = filterConst.multiSelectFilters;
    this.selectFilters = filterConst.selectFilters;

    this.displayedColumns = tableConst.COLUMNS;
  }

  ngOnInit() {
    this.search();
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
}
