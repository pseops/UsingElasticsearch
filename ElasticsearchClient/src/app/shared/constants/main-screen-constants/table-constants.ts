export const MAIN_COLUMNS = [
  {name: 'parkName', viewName: 'Park'},
  {name: 'accommName', viewName: 'Accommodation'},
  {name: 'accommBeds', viewName: 'Bedrooms'},
  {name: 'accommTypeName', viewName: 'Type'},
  {name: 'unitGradeName', viewName: 'Grade'},
  {name: 'accommPax', viewName: 'Pax'},
  {name: 'arrivalDateRevised', viewName: 'Arival Date'},
];

export const REPEATED_COLUMNS = [
  {name: 'RackRate', viewName: 'RackRate'},
  {name: 'CurrentFitPrice', viewName: 'Current Fit Price'},
  {name: 'CurrentStandardDiscount', viewName: 'Current Standard Discount'},
  {name: 'CurrentCampaignDiscount', viewName: 'Current Campaign Discount'},
  {name: 'CurrentEnhancedDiscount', viewName: 'Current Enhanced Discount'},
  {name: 'CurrentAdditionalDiscount', viewName: 'CurrentAdditionalDiscount'},
  {name: 'CurrentSellingPrice', viewName: 'Current Selling Price'},
  {name: 'NewFitPrice', viewName: 'New Fit Price'},
  {name: 'NewDiscount', viewName: 'New Discount'},
  {name: 'NewCampaignDiscount', viewName: 'New Campaign Discount'},
  {name: 'NewEnhancedDiscount', viewName: 'New Enhanced Discount'},
  {name: 'NewAdditionalDiscount', viewName: 'New Additional Discount'},
  {name: 'NewSellingPrice', viewName: 'New Selling Price'},
  {name: 'SellingPriceChange', viewName: 'Selling Price Change'},
  {name: 'IsSelect', viewName: 'IsSelect'},
  {name: 'MinimumPrice', viewName: 'Minimum Price'},
  {name: 'BookedUnitsTotal', viewName: 'Booked Units Total'},
  {name: 'BookedUnitsVarianceYoy', viewName: 'Booked Units Variance Yoy'},
  {name: 'BookedUnitsYoyAbvVariance', viewName: 'Booked Units Yoy Abv Variance'},
  {name: 'CurrentUnitsAvailable', viewName: 'Current Units Available'},
  {name: 'LastPriceChange', viewName: 'Last Price Change'},
  {name: 'DaysSinceLastChange', viewName: 'Days Since Last Change'},
  {name: 'BookingsSinceLastChange', viewName: 'Bookings Since Last Change'},

];

export const PREFIX_NAME = [
  'fri',
  'sat',
  'mon',
];

export const TOP_HEADERS = [
  {name: ' ', count: MAIN_COLUMNS.length, sticky: true},
  {name: 'Friday', count: REPEATED_COLUMNS.length, sticky: false},
  {name: 'Saturday', count: REPEATED_COLUMNS.length, sticky: false},
  {name: 'Monday', count: REPEATED_COLUMNS.length, sticky: false},
];

