﻿// <auto-generated />
using System;
using DataAccess.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccess.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsRemoved");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("DataAccess.Entities.LogException", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnName("CreationDate");

                    b.Property<bool>("IsRemoved")
                        .HasColumnName("IsRemoved");

                    b.Property<string>("Message")
                        .HasColumnName("Message");

                    b.Property<string>("Request")
                        .HasColumnName("Request");

                    b.Property<string>("Source")
                        .HasColumnName("Source");

                    b.Property<string>("StackTrace")
                        .HasColumnName("StackTrace");

                    b.Property<string>("UserId")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("LogExceptions");
                });

            modelBuilder.Entity("DataAccess.Entities.WebAppData", b =>
                {
                    b.Property<int>("RecId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rec_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccommBeds")
                        .HasColumnName("accomm_beds");

                    b.Property<int?>("AccommId")
                        .HasColumnName("accomm_id");

                    b.Property<string>("AccommName")
                        .HasColumnName("accomm_name");

                    b.Property<int?>("AccommPax")
                        .HasColumnName("accomm_pax");

                    b.Property<string>("AccommTypeName")
                        .HasColumnName("accomm_type_name");

                    b.Property<decimal?>("AccommWeekOccupancy")
                        .HasColumnName("accomm_week_occupancy");

                    b.Property<bool>("AllNotAproved")
                        .HasColumnName("all_not_aproved");

                    b.Property<DateTime?>("ArrivalDateRevised")
                        .HasColumnName("arrival_date_revised");

                    b.Property<int?>("FriBookedUnitsTotal")
                        .HasColumnName("fri_booked_units_total");

                    b.Property<int?>("FriBookedUnitsVarianceYoy")
                        .HasColumnName("fri_booked_units_variance_yoy");

                    b.Property<decimal?>("FriBookedUnitsYoyAbvVariance")
                        .HasColumnName("fri_booked_units_yoy_abv_variance");

                    b.Property<int?>("FriBookingsSinceLastChange")
                        .HasColumnName("fri_bookings_since_last_change");

                    b.Property<decimal?>("FriCurrentAdditionalDiscount")
                        .HasColumnName("fri_current_additional_discount");

                    b.Property<decimal?>("FriCurrentCampaignDiscount")
                        .HasColumnName("fri_current_campaign_discount");

                    b.Property<decimal?>("FriCurrentEnhancedDiscount")
                        .HasColumnName("fri_current_enhanced_discount");

                    b.Property<decimal?>("FriCurrentFitPrice")
                        .HasColumnName("fri_current_fit_price");

                    b.Property<decimal?>("FriCurrentSellingPrice")
                        .HasColumnName("fri_current_selling_price");

                    b.Property<decimal?>("FriCurrentStandardDiscount")
                        .HasColumnName("fri_current_standard_discount");

                    b.Property<int?>("FriCurrentUnitsAvailable")
                        .HasColumnName("fri_current_units_available");

                    b.Property<int?>("FriDaysSinceLastChange")
                        .HasColumnName("fri_days_since_last_change");

                    b.Property<decimal?>("FriLastPriceChange")
                        .HasColumnName("fri_last_price_change");

                    b.Property<decimal?>("FriMinimumPrice")
                        .HasColumnName("fri_minimum_price");

                    b.Property<decimal?>("FriNewAdditionalDiscount")
                        .HasColumnName("fri_new_additional_discount");

                    b.Property<decimal?>("FriNewCampaignDiscount")
                        .HasColumnName("fri_new_campaign_discount");

                    b.Property<decimal?>("FriNewDiscount")
                        .HasColumnName("fri_new_discount");

                    b.Property<decimal?>("FriNewEnhancedDiscount")
                        .HasColumnName("fri_new_enhanced_discount");

                    b.Property<decimal?>("FriNewFitPrice")
                        .HasColumnName("fri_new_fit_price");

                    b.Property<decimal?>("FriNewSellingPrice")
                        .HasColumnName("fri_new_selling_price");

                    b.Property<int?>("FriPriceChangeStatus")
                        .HasColumnName("fri_price_change_status");

                    b.Property<decimal?>("FriRackRate")
                        .HasColumnName("fri_rack_rate");

                    b.Property<decimal?>("FriRecommendedDiscount")
                        .HasColumnName("fri_recommended_discount");

                    b.Property<decimal?>("FriRecommendedFitPrice")
                        .HasColumnName("fri_recommended_fit_price");

                    b.Property<decimal?>("FriRecommendedSellingPrice")
                        .HasColumnName("fri_recommended_selling_price");

                    b.Property<decimal?>("FriSellingPriceChange")
                        .HasColumnName("fri_selling_price_change");

                    b.Property<string>("FriUpdatedBy")
                        .HasColumnName("fri_updated_by");

                    b.Property<int?>("HolidayYear")
                        .HasColumnName("holiday_year");

                    b.Property<string>("KeyPeriodName")
                        .HasColumnName("key_period_name");

                    b.Property<int?>("MonBookedUnitsTotal")
                        .HasColumnName("mon_booked_units_total");

                    b.Property<int?>("MonBookedUnitsVarianceYoy")
                        .HasColumnName("mon_booked_units_variance_yoy");

                    b.Property<decimal?>("MonBookedUnitsYoyAbvVariance")
                        .HasColumnName("mon_booked_units_yoy_abv_variance");

                    b.Property<int?>("MonBookingsSinceLastChange")
                        .HasColumnName("mon_bookings_since_last_change");

                    b.Property<decimal?>("MonCurrentAdditionalDiscount")
                        .HasColumnName("mon_current_additional_discount");

                    b.Property<decimal?>("MonCurrentCampaignDiscount")
                        .HasColumnName("mon_current_campaign_discount");

                    b.Property<decimal?>("MonCurrentEnhancedDiscount")
                        .HasColumnName("mon_current_enhanced_discount");

                    b.Property<decimal?>("MonCurrentFitPrice")
                        .HasColumnName("mon_current_fit_price");

                    b.Property<decimal?>("MonCurrentSellingPrice")
                        .HasColumnName("mon_current_selling_price");

                    b.Property<decimal?>("MonCurrentStandardDiscount")
                        .HasColumnName("mon_current_standard_discount");

                    b.Property<int?>("MonCurrentUnitsAvailable")
                        .HasColumnName("mon_current_units_available");

                    b.Property<int?>("MonDaysSinceLastChange")
                        .HasColumnName("mon_days_since_last_change");

                    b.Property<decimal?>("MonLastPriceChange")
                        .HasColumnName("mon_last_price_change");

                    b.Property<decimal?>("MonMinimumPrice")
                        .HasColumnName("mon_minimum_price");

                    b.Property<decimal?>("MonNewAdditionalDiscount")
                        .HasColumnName("mon_new_additional_discount");

                    b.Property<decimal?>("MonNewCampaignDiscount")
                        .HasColumnName("mon_new_campaign_discount");

                    b.Property<decimal?>("MonNewDiscount")
                        .HasColumnName("mon_new_discount");

                    b.Property<decimal?>("MonNewEnhancedDiscount")
                        .HasColumnName("mon_new_enhanced_discount");

                    b.Property<decimal?>("MonNewFitPrice")
                        .HasColumnName("mon_new_fit_price");

                    b.Property<decimal?>("MonNewSellingPrice")
                        .HasColumnName("mon_new_selling_price");

                    b.Property<int?>("MonPriceChangeStatus")
                        .HasColumnName("mon_price_change_status");

                    b.Property<decimal?>("MonRackRate")
                        .HasColumnName("mon_rack_rate");

                    b.Property<decimal?>("MonRecommendedDiscount")
                        .HasColumnName("mon_recommended_discount");

                    b.Property<decimal?>("MonRecommendedFitPrice")
                        .HasColumnName("mon_recommended_fit_price");

                    b.Property<decimal?>("MonRecommendedSellingPrice")
                        .HasColumnName("mon_recommended_selling_price");

                    b.Property<decimal?>("MonSellingPriceChange")
                        .HasColumnName("mon_selling_price_change");

                    b.Property<string>("MonUpdatedBy")
                        .HasColumnName("mon_updated_by");

                    b.Property<int?>("ParkId")
                        .HasColumnName("park_id");

                    b.Property<string>("ParkName")
                        .HasColumnName("park_name");

                    b.Property<decimal?>("ParkNightsTargetDeviation")
                        .HasColumnName("park_nights_target_deviation");

                    b.Property<decimal?>("ParkPrioritisationScore")
                        .HasColumnName("park_prioritisation_score");

                    b.Property<decimal?>("ParkWeekOccupancy")
                        .HasColumnName("park_week_occupancy");

                    b.Property<short?>("ProfileTypeId")
                        .HasColumnName("profile_type_id");

                    b.Property<string>("RegionName")
                        .HasColumnName("region_name");

                    b.Property<string>("ResponsibleRevenueManager")
                        .HasColumnName("responsible_revenue_manager");

                    b.Property<string>("RowId")
                        .HasColumnName("row_id");

                    b.Property<int?>("SatBookedUnitsTotal")
                        .HasColumnName("sat_booked_units_total");

                    b.Property<int?>("SatBookedUnitsVarianceYoy")
                        .HasColumnName("sat_booked_units_variance_yoy");

                    b.Property<decimal?>("SatBookedUnitsYoyAbvVariance")
                        .HasColumnName("sat_booked_units_yoy_abv_variance");

                    b.Property<int?>("SatBookingsSinceLastChange")
                        .HasColumnName("sat_bookings_since_last_change");

                    b.Property<decimal?>("SatCurrentAdditionalDiscount")
                        .HasColumnName("sat_current_additional_discount");

                    b.Property<decimal?>("SatCurrentCampaignDiscount")
                        .HasColumnName("sat_current_campaign_discount");

                    b.Property<decimal?>("SatCurrentEnhancedDiscount")
                        .HasColumnName("sat_current_enhanced_discount");

                    b.Property<decimal?>("SatCurrentFitPrice")
                        .HasColumnName("sat_current_fit_price");

                    b.Property<decimal?>("SatCurrentSellingPrice")
                        .HasColumnName("sat_current_selling_price");

                    b.Property<decimal?>("SatCurrentStandardDiscount")
                        .HasColumnName("sat_current_standard_discount");

                    b.Property<int?>("SatCurrentUnitsAvailable")
                        .HasColumnName("sat_current_units_available");

                    b.Property<int?>("SatDaysSinceLastChange")
                        .HasColumnName("sat_days_since_last_change");

                    b.Property<decimal?>("SatLastPriceChange")
                        .HasColumnName("sat_last_price_change");

                    b.Property<decimal?>("SatMinimumPrice")
                        .HasColumnName("sat_minimum_price");

                    b.Property<decimal?>("SatNewAdditionalDiscount")
                        .HasColumnName("sat_new_additional_discount");

                    b.Property<decimal?>("SatNewCampaignDiscount")
                        .HasColumnName("sat_new_campaign_discount");

                    b.Property<decimal?>("SatNewDiscount")
                        .HasColumnName("sat_new_discount");

                    b.Property<decimal?>("SatNewEnhancedDiscount")
                        .HasColumnName("sat_new_enhanced_discount");

                    b.Property<decimal?>("SatNewFitPrice")
                        .HasColumnName("sat_new_fit_price");

                    b.Property<decimal?>("SatNewSellingPrice")
                        .HasColumnName("sat_new_selling_price");

                    b.Property<short?>("SatPriceChangeStatus")
                        .HasColumnName("sat_price_change_status");

                    b.Property<decimal?>("SatRackRate")
                        .HasColumnName("sat_rack_rate");

                    b.Property<decimal?>("SatRecommendedDiscount")
                        .HasColumnName("sat_recommended_discount");

                    b.Property<decimal?>("SatRecommendedFitPrice")
                        .HasColumnName("sat_recommended_fit_price");

                    b.Property<decimal?>("SatRecommendedSellingPrice")
                        .HasColumnName("sat_recommended_selling_price");

                    b.Property<decimal?>("SatSellingPriceChange")
                        .HasColumnName("sat_selling_price_change");

                    b.Property<string>("SatUpdatedBy")
                        .HasColumnName("sat_updated_by");

                    b.Property<decimal?>("UnitFradeNightsTargetDeviation")
                        .HasColumnName("unit_grade_nights_target_deviation");

                    b.Property<string>("UnitGradeName")
                        .HasColumnName("unit_grade_name");

                    b.Property<decimal?>("UnitGradePrioritisationScore")
                        .HasColumnName("unit_grade_prioritisation_score");

                    b.Property<int?>("UnitGradeRecencyOfLastSale")
                        .HasColumnName("unit_grade_recency_of_last_sale");

                    b.Property<decimal?>("UnitGradeWeekOccupancy")
                        .HasColumnName("unit_grade_week_occupancy");

                    b.Property<int?>("WeekNumber")
                        .HasColumnName("week_number");

                    b.HasKey("RecId");

                    b.ToTable("SKP_Web_App_Data");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DataAccess.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DataAccess.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DataAccess.Entities.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
