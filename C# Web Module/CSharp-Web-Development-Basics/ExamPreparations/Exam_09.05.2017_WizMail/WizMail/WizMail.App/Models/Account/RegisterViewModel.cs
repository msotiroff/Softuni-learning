namespace WizMail.App.Models.User
{
    using System.ComponentModel.DataAnnotations;
    using WizMail.Models.Common;

    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(ModelConstants.UsernamePattern, ErrorMessage = ModelConstants.UsernameValidationErrorMsg)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(ModelConstants.FirstNameMaxLenght, MinimumLength = ModelConstants.FirstNameMinLenght)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(ModelConstants.LastNameMaxLenght, MinimumLength = ModelConstants.LastNameMinLenght)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(ModelConstants.PasswordPattern, ErrorMessage = ModelConstants.PasswordValidationErrorMsg)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Repeat password")]
        [Compare(nameof(Password))]
        public string RepeatPassword { get; set; }
    }
}
