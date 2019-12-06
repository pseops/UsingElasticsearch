using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Common.Models
{
    public class RangeSearchFilter
    {
        public int From { get; set; }
        public int Count { get; set; }
        public string ColumnName { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }
}
