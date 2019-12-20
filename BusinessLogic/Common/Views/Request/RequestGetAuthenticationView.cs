﻿using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Common.Views.Request
{
    public class RequestGetAuthenticationView
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
