using System.Collections.Generic;

namespace Common.Views.MainScreen.Response
{
    public class ResponseGetFiltersMainScreenView
    {
        public List<string> Items { get; set; }
        public ResponseGetFiltersMainScreenView()
        {
            Items = new List<string>();
        }
    }
}
