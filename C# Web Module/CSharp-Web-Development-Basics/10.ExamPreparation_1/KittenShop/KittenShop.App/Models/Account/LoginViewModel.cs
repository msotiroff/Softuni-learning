﻿using System.ComponentModel.DataAnnotations;

namespace KittenShop.App.Models.User
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
