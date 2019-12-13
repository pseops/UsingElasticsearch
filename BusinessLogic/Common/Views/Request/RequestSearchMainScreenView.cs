using BusinessLogic.Common.Models;

namespace BusinessLogic.Common.Views.Request
{
    public class RequestSearchMainScreenView
    {
        public int From { get; set; }
        public int Count { get; set; }
        public FiltersModel Filters { get; set; }
    }
}
