namespace BusinessLogic.Common.Views.Response.User
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
        public string Role { get; set; }
    }
}
