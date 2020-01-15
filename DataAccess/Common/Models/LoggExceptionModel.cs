using DataAccess.Entities;
using System.Collections.Generic;

namespace DataAccess.Common.Models
{
    public class LoggExceptionModel
    {
        public List<LogException> Items { get; set; }
        public int Count { get; set; }
    }
}
