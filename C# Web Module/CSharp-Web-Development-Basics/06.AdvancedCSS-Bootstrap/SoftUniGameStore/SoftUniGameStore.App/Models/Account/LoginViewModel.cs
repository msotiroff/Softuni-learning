namespace SoftUniGameStore.App.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        private const string PasswordPattern = "(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,}";
        private const string PasswordErrorMsg
            = "Invalid password! It should be at least 6 symbols long, containing 1 uppercase letter, 1 lowerc ase letter and 1 digit";

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(PasswordPattern, ErrorMessage = PasswordErrorMsg)]
        public string Password { get; set; }
    }
}
