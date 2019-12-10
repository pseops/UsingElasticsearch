export class RequestDropDownValues {
  currentFilter: string;
  size: number;
  holidayYear: string[];
  regionName: string[];
  weekNumber: string[];
  responsibleRevenueManager: string[];
  parkName: string[];
  accommTypeName: string[];
  accommBeds: string[];
  unitGradeName: string[];
  accommName: string[];
  keyPeriodName: string[];

  constructor() {
    this.currentFilter = null;
    this.size = 1000;
    this.holidayYear = [null];
    this.regionName = [null];
    this.weekNumber = [null];
    this.responsibleRevenueManager = [null];
    this.parkName = [null];
    this.accommBeds = [null];
    this.accommName = [null];
    this.accommTypeName = [null];
    this.unitGradeName = [null];
    this.keyPeriodName = [null];
  }
}
