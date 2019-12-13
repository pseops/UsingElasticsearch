using System.Collections.Generic;

namespace BusinessLogic.Common.Views.Response
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
