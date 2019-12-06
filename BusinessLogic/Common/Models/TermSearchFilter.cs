using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Common.Models
{
    public class TermSearchFilter
    {
        public int From { get; set; }
        public int Count { get; set; }
        public string ColumnName { get; set; }
        public IEnumerable<string> Values { get; set; }
    }
}
