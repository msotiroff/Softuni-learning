namespace SoftUniGameStore.Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginServiceModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
