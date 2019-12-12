export class FiltersModel {
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
  lessParkWeekOccupancy?: number;
  greaterParkWeekOccupancy?: number;

  constructor() {
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
    this.lessParkWeekOccupancy = null;
    this.greaterParkWeekOccupancy = null;
  }
}
