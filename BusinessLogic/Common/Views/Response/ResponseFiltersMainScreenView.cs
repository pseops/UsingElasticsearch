using System.Collections.Generic;

namespace BusinessLogic.Common.Views.Response
{
    public class ResponseFiltersMainScreenView
    {
        public List<string> Items { get; set; }
        public ResponseFiltersMainScreenView()
        {
            Items = new List<string>();
        }
    }
}
