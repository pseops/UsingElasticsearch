import { Component, OnInit } from '@angular/core';
import { SearchService } from '../core/services/search.service';
import { WebAppDataView, RangeSearchFilterView, WebAppDataViewItem, TermSearchFilterView } from '../shared/models';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Sort } from '@angular/material/sort';

@Component({
  selector: 'app-search-filter',
  templateUrl: './search-filter.component.html',
  styleUrls: ['./search-filter.component.css']
})
export class SearchFilterComponent implements OnInit {
  webAppData: WebAppDataView;
  rangeFilter: RangeSearchFilterView;
  termFilter: TermSearchFilterView;
  rangeFilterForm: FormGroup;
  termFilterForm: FormGroup;
  displayedColumns: string[];
  constructor(
    private searchService: SearchService,
    private formBuilder: FormBuilder,
    ) {
      this.webAppData = new WebAppDataView();
      this.rangeFilter = new RangeSearchFilterView();
      this.termFilter = new TermSearchFilterView();
      this.buildForms();
      this.displayedColumns = ['recId', 'rowId', 'profileTypeId', 'holidayYear', 'weekNumber', 'keyPeriodName', 'regionName'];

      this.setupTestFilter();
    }

  ngOnInit() {
    this.rangeSearch();
  }

  private setupTestFilter(): void {
    this.rangeFilter.columnName = 'recId';
    this.rangeFilter.count = 10;
    this.rangeFilter.from = 0;
    this.rangeFilter.minValue = 0;
    this.rangeFilter.maxValue = 10;
  }

  private buildForms(): void {
    this.rangeFilterForm = this.formBuilder.group({
      columnName: ['', Validators.required],
      minValue: ['', Validators.required],
      maxValue: ['', Validators.required],
   });
    this.termFilterForm = this.formBuilder.group({
      columnName: ['', Validators.required],
      values: ['', Validators.required]
  });
  }

  termSearch(): void {
    if (!this.termFilterForm.valid) {
      return;
    }

    this.termFilter.from = this.rangeFilter.from;
    this.termFilter.count = this.rangeFilter.count;

    this.searchService.termSearch(this.termFilter).subscribe((data) => {
      this.webAppData = data;
    });
  }

  rangeSearch(): void {
    if (!this.rangeFilterForm.valid) {
      return;
    }
    this.searchService.rangeSearch(this.rangeFilter).subscribe((data) => {
      this.webAppData = data;
    });
  }

  handlePage(e: any): void {
    this.rangeFilter.from = e.pageIndex * e.pageSize;
    this.rangeFilter.count = e.pageSize;

    this.rangeSearch();
  }

  sortData(sort: Sort): void {
    // this.printingEditionFilterModel.SortColumn = SortColumnType[sort.active];
    // this.printingEditionFilterModel.SortType = SortType[sort.direction];

    // this.getPrintingEditions();
  }
}
