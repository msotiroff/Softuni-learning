namespace ModPanel.App.Models.User
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        private const string PasswordErrorMsg = "Password length must be at least 6 symbols and must contain at least 1 uppercase, 1 lowercase letter and 1 digit";

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}", ErrorMessage = PasswordErrorMsg)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Position { get; set; }
    }
}
