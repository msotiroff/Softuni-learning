namespace Airport.App.Models.User
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Repeat password")]
        [Compare(nameof(Password))]
        public string RepeatPassword { get; set; }
    }
}
