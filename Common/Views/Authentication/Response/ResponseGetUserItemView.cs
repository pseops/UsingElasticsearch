using Common.Models;
using System.Collections.Generic;
using static Common.Enums.Enums;

namespace Common.Views.Authetication.Response
{
    public class ResponseGetUserItemView
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; } = true;
        public UserRole Role { get; set; }
        public List<UsersPermissionsModel> Permissions { get; set; }
    }
}
