using DataAccess.Entities;
using System.Collections.Generic;

namespace BusinessLogic.Common.Views.Response
{
    public class ResponseSearchMainScreenView
    {
        public List<WebAppData> Items { get; set; }
        public long ItemsCount { get; set; }
    }
}
