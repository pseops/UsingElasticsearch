using System.ComponentModel.DataAnnotations;

namespace Common.Views.Authetication.Request
{
    public class RequestGetAuthenticationView
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
