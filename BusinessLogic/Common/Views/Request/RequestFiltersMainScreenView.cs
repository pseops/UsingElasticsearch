using BusinessLogic.Common.Models;
using System.Collections.Generic;
using static BusinessLogic.Enums.Enums;

namespace BusinessLogic.Common.Views.Request
{
    public class RequestFiltersMainScreenView
    {
        public FilterName CurrentFilter { get; set; }
        public int Size { get; set; }
        public FiltersModel Filters { get; set; }

    }
}
