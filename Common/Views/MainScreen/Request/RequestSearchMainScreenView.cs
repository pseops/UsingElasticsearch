using Common.Models;

namespace Common.Views.MainScreen.Request
{
    public class RequestSearchMainScreenView
    {
        public int From { get; set; }
        public int Count { get; set; }
        public FiltersModel Filters { get; set; }
    }
}
