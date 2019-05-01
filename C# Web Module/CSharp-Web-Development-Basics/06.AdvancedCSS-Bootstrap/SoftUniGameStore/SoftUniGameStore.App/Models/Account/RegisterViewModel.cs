namespace SoftUniGameStore.App.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        private const string PasswordPattern = "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,}";
        private const string PasswordErrorMsg 
            = "Invalid password! It should be at least 6 symbols long, containing 1 uppercase letter, 1 lowerc ase letter and 1 digit";
        private const string FullNameErrorMsg = "Full name should contains only letters, spaces, dots and slashes!";

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z -.]+$", ErrorMessage = FullNameErrorMsg)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(PasswordPattern, ErrorMessage = PasswordErrorMsg)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(PasswordPattern, ErrorMessage = PasswordErrorMsg)]
        public string ConfirmPassword { get; set; }
    }
}
