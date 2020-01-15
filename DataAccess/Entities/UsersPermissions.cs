using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DataAccess.Entities.Enums.Enums;

namespace DataAccess.Entities
{
    public class UsersPermissions
    {
        [Key]
        public long Id { get; set; }
        public bool CanEdit { get; set; }
        public bool CanView { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public Page Page { get; set; }
    }
}
