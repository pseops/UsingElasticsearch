using static Common.Enums.Enums;

namespace Common.Models
{
    public class UsersPermissionsModel
    {
        public long Id { get; set; }
        public bool CanEdit { get; set; }
        public bool CanView { get; set; }
        public string UserId { get; set; }
        public Page Page { get; set; }
    }
}
