namespace ByTheCake.Services.Models
{
    using ByTheCake.Models.Common;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserCreateServiceModel
    {
        [Required]
        [MinLength(ModelConstants.UserNameMinLength)]
        [MaxLength(ModelConstants.UserNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ModelConstants.UserUsernameMinLength)]
        [MaxLength(ModelConstants.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}
