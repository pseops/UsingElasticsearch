using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Common.Models
{
    public class SearchResponseView
    {
        public List<WebAppData> Items { get; set; }
        public long ItemsCount { get; set; }
    }
}
