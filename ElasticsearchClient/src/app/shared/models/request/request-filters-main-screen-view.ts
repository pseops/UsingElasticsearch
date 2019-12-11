import { FiltersModel } from './filters-model';

export class RequestFiltersMainScreenView {
  currentFilter: number;
  size: number;
  from: number;
  count: number;
  sortColumn: string;
  sortOrder: number;
  filters: FiltersModel;

  constructor() {
    this.reset();
  }

  reset(): void {
    this.currentFilter = 0;
    this.size = 1000;
    this.from = 0;
    this.count = 10;
    this.filters = new FiltersModel();
  }
}
