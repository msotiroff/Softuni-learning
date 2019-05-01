namespace SoftUniClone.Services.Models.Users
{
    using Common.Mapping;
    using SoftUniClone.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    
    public class UserEditProfileServiceModel : IAutoMapWith<User>
    {
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}