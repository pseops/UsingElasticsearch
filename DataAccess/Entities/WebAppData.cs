using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class WebAppData
    {
        [Column("rec_id")]
        public int RecId { get; set; }
        [Column("row_id")]
        public string RowId { get; set; }
        [Column("profile_type_id")]
        public short? ProfileTypeId { get; set; }
        [Column("holiday_year")]
        public int? HolidayYear { get; set; }
        [Column("week_number")]
        public int? WeekNumber { get; set; }
        [Column("key_period_name")]
        public string KeyPeriodName { get; set; }
        [Column("region_name")]
        public string RegionName { get; set; }
        [Column("park_name")]
        public string ParkName { get; set; }
        [Column("park_id")]
        public int? ParkId { get; set; }
        [Column("accomm_id")]
        public int? AccommId { get; set; }
        [Column("accomm_name")]
        public string AccommName { get; set; }
        [Column("accomm_type_name")]
        public string AccommTypeName { get; set; }
        [Column("accomm_beds")]
        public int? AccommBeds { get; set; }
        [Column("accomm_pax")]
        public int? AccommPax { get; set; }
        [Column("unit_grade_name")]
        public string UnitGradeName { get; set; }
        [Column("arrival_date_revised")]
        public DateTime? ArrivalDateRevised { get; set; }
        [Column("responsible_revenue_manager")]
        public string ResponsibleRevenueManager { get; set; }
        [Column("park_prioritisation_score")]
        public decimal? ParkPrioritisationScore { get; set; }
        [Column("park_nights_target_deviation")]
        public decimal? ParkNightsTargetDeviation { get; set; }
        [Column("park_week_occupancy")]
        public decimal? ParkWeekOccupancy { get; set; }
        [Column("unit_grade_prioritisation_score")]
        public decimal? UnitGradePrioritisationScore { get; set; }
        [Column("unit_grade_nights_target_deviation")]
        public decimal? UnitFradeNightsTargetDeviation { get; set; }
        [Column("unit_grade_week_occupancy")]
        public decimal? UnitGradeWeekOccupancy { get; set; }
        [Column("unit_grade_recency_of_last_sale")]
        public int? UnitGradeRecencyOfLastSale { get; set; }
        [Column("accomm_week_occupancy")]
        public decimal? AccommWeekOccupancy { get; set; }
        [Column("fri_rack_rate")]
        public decimal? FriRackRate { get; set; }
        [Column("fri_current_fit_price")]
        public decimal? FriCurrentFitPrice { get; set; }
        [Column("fri_current_standard_discount")]
        public decimal? FriCurrentStandardDiscount { get; set; }
        [Column("fri_current_enhanced_discount")]
        public decimal? FriCurrentEnhancedDiscount { get; set; }
        [Column("fri_current_campaign_discount")]
        public decimal? FriCurrentCampaignDiscount { get; set; }
        [Column("fri_current_additional_discount")]
        public decimal? FriCurrentAdditionalDiscount { get; set; }
        [Column("fri_current_selling_price")]
        public decimal? FriCurrentSellingPrice { get; set; }
        [Column("fri_recommended_fit_price")]
        public decimal? FriRecommendedFitPrice { get; set; }
        [Column("fri_new_fit_price")]
        public decimal? FriNewFitPrice { get; set; }
        [Column("fri_recommended_discount")]
        public decimal? FriRecommendedDiscount { get; set; }
        [Column("fri_new_discount")]
        public decimal? FriNewDiscount { get; set; }
        [Column("fri_new_enhanced_discount")]
        public decimal? FriNewEnhancedDiscount { get; set; }
        [Column("fri_new_campaign_discount")]
        public decimal? FriNewCampaignDiscount { get; set; }
        [Column("fri_new_additional_discount")]
        public decimal? FriNewAdditionalDiscount { get; set; }
        [Column("fri_recommended_selling_price")]
        public decimal? FriRecommendedSellingPrice { get; set; }
        [Column("fri_new_selling_price")]
        public decimal? FriNewSellingPrice { get; set; }
        [Column("fri_selling_price_change")]
        public decimal? FriSellingPriceChange { get; set; }
        [Column("fri_price_change_status")]
        public int? FriPriceChangeStatus { get; set; }
        [Column("fri_booked_units_total")]
        public int? FriBookedUnitsTotal { get; set; }
        [Column("fri_booked_units_variance_yoy")]
        public int? FriBookedUnitsVarianceYoy { get; set; }
        [Column("fri_booked_units_yoy_abv_variance")]
        public decimal? FriBookedUnitsYoyAbvVariance { get; set; }
        [Column("fri_current_units_available")]
        public int? FriCurrentUnitsAvailable { get; set; }
        [Column("fri_last_price_change")]
        public decimal? FriLastPriceChange { get; set; }
        [Column("fri_days_since_last_change")]
        public int? FriDaysSinceLastChange { get; set; }
        [Column("fri_bookings_since_last_change")]
        public int? FriBookingsSinceLastChange { get; set; }
        [Column("fri_minimum_price")]
        public decimal? FriMinimumPrice { get; set; }
        [Column("fri_updated_by")]
        public string FriUpdatedBy { get; set; }
        [Column("sat_rack_rate")]
        public decimal? SatRackRate { get; set; }
        [Column("sat_current_fit_price")]
        public decimal? SatCurrentFitPrice { get; set; }
        [Column("sat_current_standard_discount")]
        public decimal? SatCurrentStandardDiscount { get; set; }
        [Column("sat_current_enhanced_discount")]
        public decimal? SatCurrentEnhancedDiscount { get; set; }
        [Column("sat_current_campaign_discount")]
        public decimal? SatCurrentCampaignDiscount { get; set; }
        [Column("sat_current_additional_discount")]
        public decimal? SatCurrentAdditionalDiscount { get; set; }
        [Column("sat_current_selling_price")]
        public decimal? SatCurrentSellingPrice { get; set; }
        [Column("sat_recommended_fit_price")]
        public decimal? SatRecommendedFitPrice { get; set; }
        [Column("sat_new_fit_price")]
        public decimal? SatNewFitPrice { get; set; }
        [Column("sat_recommended_discount")]
        public decimal? SatRecommendedDiscount { get; set; }
        [Column("sat_new_discount")]
        public decimal? SatNewDiscount { get; set; }
        [Column("sat_new_enhanced_discount")]
        public decimal? SatNewEnhancedDiscount { get; set; }
        [Column("sat_new_campaign_discount")]
        public decimal? SatNewCampaignDiscount { get; set; }
        [Column("sat_new_additional_discount")]
        public decimal? SatNewAdditionalDiscount { get; set; }
        [Column("sat_recommended_selling_price")]
        public decimal? SatRecommendedSellingPrice { get; set; }
        [Column("sat_new_selling_price")]
        public decimal? SatNewSellingPrice { get; set; }
        [Column("sat_selling_price_change")]
        public decimal? SatSellingPriceChange { get; set; }
        [Column("sat_price_change_status")]
        public short? SatPriceChangeStatus { get; set; }
        [Column("rec_id")]
        public Nullable<int> sat_booked_units_total { get; set; }
        [Column("rec_id")]
        public Nullable<int> sat_booked_units_variance_yoy { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> sat_booked_units_yoy_abv_variance { get; set; }
        [Column("rec_id")]
        public Nullable<int> sat_current_units_available { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> sat_last_price_change { get; set; }
        [Column("rec_id")]
        public Nullable<int> sat_days_since_last_change { get; set; }
        [Column("rec_id")]
        public Nullable<int> sat_bookings_since_last_change { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> sat_minimum_price { get; set; }
        [Column("rec_id")]
        public string sat_updated_by { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_rack_rate { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_current_fit_price { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_current_standard_discount { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_current_enhanced_discount { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_current_campaign_discount { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_current_additional_discount { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_current_selling_price { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_recommended_fit_price { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_new_fit_price { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_recommended_discount { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_new_discount { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_new_enhanced_discount { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_new_campaign_discount { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_new_additional_discount { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_recommended_selling_price { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_new_selling_price { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_selling_price_change { get; set; }
        [Column("rec_id")]
        public Nullable<int> mon_price_change_status { get; set; }
        [Column("rec_id")]
        public Nullable<int> mon_booked_units_total { get; set; }
        [Column("rec_id")]
        public Nullable<int> mon_booked_units_variance_yoy { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_booked_units_yoy_abv_variance { get; set; }
        [Column("rec_id")]
        public Nullable<int> mon_current_units_available { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_last_price_change { get; set; }
        [Column("rec_id")]
        public Nullable<int> mon_days_since_last_change { get; set; }
        [Column("rec_id")]
        public Nullable<int> mon_bookings_since_last_change { get; set; }
        [Column("rec_id")]
        public Nullable<decimal> mon_minimum_price { get; set; }
        [Column("rec_id")]
        public string mon_updated_by { get; set; }
        [Column("rec_id")]
        public bool all_not_aproved { get; set; }
    }
}
