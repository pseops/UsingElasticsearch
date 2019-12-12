using DataAccess.Entities;
using System;
using Nest;
using BusinessLogic.Common.Models;

namespace BusinessLogic.Helpers
{
    public static class FilterHelper
    {

        public static string GetFilterName(this string filter)
        {           

            var property = typeof(WebAppData).GetProperty(filter.FirstLetterToUpper());

            var filterName = property.Name.FirstLetterToLower();
            
            var type = property.PropertyType;
            
            if (type.Equals(typeof(String)))
            {
                filterName += ".keyword";
            }

            return filterName;
        }

        public static QueryContainerDescriptor<WebAppData> SearchQuery(this QueryContainerDescriptor<WebAppData> query, FiltersModel request)
        {
            query.Bool(b => b
                      .Must(m => m
                          .Terms(t => t.Field(nameof(request.HolidayYear).GetFilterName()).Terms(request.HolidayYear)
                          ), m => m
                          .Terms(t => t.Field(nameof(request.RegionName).GetFilterName()).Terms(request.RegionName)
                          ), m => m
                          .Terms(t => t.Field(nameof(request.ResponsibleRevenueManager).GetFilterName()).Terms(request.ResponsibleRevenueManager)
                          ), m => m
                          .Terms(t => t.Field(nameof(request.WeekNumber).GetFilterName()).Terms(request.WeekNumber)
                          ), m => m
                          .Terms(t => t.Field(nameof(request.ParkName).GetFilterName()).Terms(request.ParkName)
                          ), m => m
                          .Terms(t => t.Field(nameof(request.AccommTypeName).GetFilterName()).Terms(request.AccommTypeName)
                          ), m => m
                          .Terms(t => t.Field(nameof(request.AccommBeds).GetFilterName()).Terms(request.AccommBeds)
                          ), m => m
                          .Terms(t => t.Field(nameof(request.AccommName).GetFilterName()).Terms(request.AccommName)
                          ), m => m
                          .Terms(t => t.Field(nameof(request.UnitGradeName).GetFilterName()).Terms(request.UnitGradeName)
                          ), m => m
                          .Terms(t => t.Field(nameof(request.KeyPeriodName).GetFilterName()).Terms(request.KeyPeriodName)
                          ), m => m
                          .TermRange(t=>t.Field(f => f.ParkWeekOccupancy).GreaterThanOrEquals(request.GreaterParkWeekOccupancy).LessThanOrEquals(request.LessParkWeekOccupancy))
                      )
                    );
            return query;
        }

        //public static SortDescriptor<WebAppData> SortBy(this SortDescriptor<WebAppData>, )
        //{

        //}

        public static string FirstLetterToLower(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            str = str.Substring(0, 1).ToLower() + str.Substring(1);

            return str;
        }

        public static string FirstLetterToUpper(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            str = str.Substring(0, 1).ToUpper() + str.Substring(1);

            return str;
        }
    }
}
