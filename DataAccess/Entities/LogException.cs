using DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities
{   
    [Table("LogExceptions")]
    public class LogException : BaseEntity
    {
        [Column("Request")]
        public string Request { get; set; }

        [Column("Source")]
        public string Source { get; set; }

        [Column("Message")]
        public string Message { get; set; }

        [Column("StackTrace")]
        public string StackTrace { get; set; }
        [Column("UserId")]
        public string UserId { get; set; }
    }
}
