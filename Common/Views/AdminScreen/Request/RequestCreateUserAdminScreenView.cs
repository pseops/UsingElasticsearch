using static Common.Enums.Enums;

namespace Common.Views.AdminScreen.Request
{
    public class RequestCreateUserAdminScreenView
    {        
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; } = true;
        public UserRole Role { get; set; }
    }
}
