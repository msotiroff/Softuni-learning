namespace SoftUniGameStore.Services.Models
{
    using SoftUniGameStore.Models.Common;
    using System.ComponentModel.DataAnnotations;

    public class UserRegisterServiceModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(ModelConstants.UsernameMinLength)]
        [MaxLength(ModelConstants.UsernameMaxLength)]
        public string FullName { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
