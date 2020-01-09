using Common.Models;
using static Common.Enums.Enums;

namespace Common.Views.MainScreen.Request
{
    public class RequestGetFiltersMainScreenView
    {
        public FilterName CurrentFilter { get; set; }
        public int Size { get; set; }
        public FiltersModel Filters { get; set; }

    }
}