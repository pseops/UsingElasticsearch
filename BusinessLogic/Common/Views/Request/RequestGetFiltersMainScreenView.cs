using BusinessLogic.Common.Models;
using static BusinessLogic.Enums.Enums;

namespace BusinessLogic.Common.Views.Request
{
    public class RequestGetFiltersMainScreenView
    {
        public FilterName CurrentFilter { get; set; }
        public int Size { get; set; }
        public FiltersModel Filters { get; set; }

    }
}