import { FiltersModel } from './filters-model';

export class RequestSearchMainScreenView {
  from: number;
  count: number;
  filters: FiltersModel;

  constructor() {
    this.reset();
  }

  reset(): void {
    this.from = 0;
    this.count = 10;
    this.filters = new FiltersModel();
  }
}

