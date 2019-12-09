using System.Collections.Generic;

namespace BusinessLogic.Common.Models.Response
{
    public class ResponseDropDownValues
    {
        public List<string> Items { get; set; }
        public ResponseDropDownValues()
        {
            Items = new List<string>();
        }
    }
}
