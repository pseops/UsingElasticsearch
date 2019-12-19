using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Common.Views.Response
{
    public class ResponseGetLoggsView
    {
        public List<LogException> Items { get; set; }
        public int Count { get; set; }
    }
}
