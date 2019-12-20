using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Entities.Base
{
    public class BaseEntity
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public long Id { get; set; }
        [Column("IsRemoved")]
        public bool IsRemoved { get; set; }
        [Column("CreationDate")]
        public DateTime CreationDate { get; set; }
        public BaseEntity()
        {           
            CreationDate = DateTime.UtcNow;
        }
    }
}
