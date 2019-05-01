namespace Notes.App.Models.User
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = "Password confirmation does not match!")]
        public string ConfirmPassword { get; set; }
    }
}
