using DataAccess.Entities;
using System;

namespace BusinessLogic.Helpers
{
    public static class DropDownFilterHelper
    {

        public static string GetFilterName(this string filter)
        {
            if (string.IsNullOrWhiteSpace(filter))
            {
                return null;
            }
            filter = filter.Substring(0,1).ToUpper()+filter.Substring(1);

            var property = typeof(WebAppData).GetProperty(filter);

            var filterName = property.Name.Substring(0,1).ToLower()+property.Name.Substring(1);
            
            var type = property.PropertyType;
            
            if (type.Equals(typeof(String)))
            {
                filterName += ".keyword";
            }

            return filterName;
        }

    }
}
