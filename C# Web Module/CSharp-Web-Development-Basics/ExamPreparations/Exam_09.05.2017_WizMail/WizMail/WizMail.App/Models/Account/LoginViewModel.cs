﻿using System.ComponentModel.DataAnnotations;

namespace WizMail.App.Models.User
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
