import { Component, OnInit } from '@angular/core';
import { SearchService } from '../../core/services/search.service';
import { WebAppDataView, RangeSearchFilterView, TermSearchFilterView } from '../../shared/models';
import { FormBuilder, FormGroup, Validators, NgModel } from '@angular/forms';
import { Sort } from '@angular/material/sort';
import { TableConstants, FilterConstants } from 'src/app/shared/constants';
import { RequestDropDownValues } from 'src/app/shared/models/request/request-drop-down-values';
import { ResponseDropDownValues } from 'src/app/shared/models/response/response-drop-down-values';
import { MatSelectChange } from '@angular/material/select';

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
  requestDropDown: RequestDropDownValues;
  storedDropDown: RequestDropDownValues;
  responseDropDown: ResponseDropDownValues;
  multiSelectFilters: string[];
  selectFilters: string[];

  constructor(
    private searchService: SearchService,
    private formBuilder: FormBuilder,
    private tableConst: TableConstants,
    private filterConst: FilterConstants
  ) {
    this.webAppData = new WebAppDataView();
    this.rangeFilter = new RangeSearchFilterView();
    this.termFilter = new TermSearchFilterView();
    this.requestDropDown = new RequestDropDownValues();
    this.storedDropDown = new RequestDropDownValues();
    this.responseDropDown = new ResponseDropDownValues();
    this.multiSelectFilters = filterConst.multiSelectFilters;
    this.selectFilters = filterConst.selectFilters;

    this.buildForms();
    this.displayedColumns = tableConst.displayedColumns;

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

  getDropDownValues(currentFilter: string): void {
    this.requestDropDown.currentFilter = currentFilter;

    this.searchService.getDropDownValues(this.requestDropDown).subscribe(data => {
      this.responseDropDown = data;
      this.storedDropDown[currentFilter] = data.items;
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
      this.requestDropDown[filter] = this.requestDropDown[filter].filter(f => !f.includes(model));
    }
  }
}
