using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using static Common.Enums.Enums;

namespace DataAccess.Entities
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsDisabled { get; set; } = false;
    }
}
