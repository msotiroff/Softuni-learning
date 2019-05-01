using System;

namespace WizMail.Models.Common
{
    public class ModelConstants
    {
        public const string EmailAddressDomain = "@WizzMail.com";

        public const int FirstNameMinLenght = 5;
        public const int FirstNameMaxLenght = 30;
        public const int LastNameMinLenght = 5;
        public const int LastNameMaxLenght = 30;

        public const string UsernamePattern = @"^[A-Za-z0-9\.]{3,20}$";
        public const string UsernameValidationErrorMsg = "Username must contain letters, digits or '.'(dot)! The size should be between 3 and 20 symbls!";

        public const string PasswordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
        public const string PasswordValidationErrorMsg = "Password length must be at least 8 symbols and must contain at least 1 uppercase, 1 lowercase letter and 1 digit";
    }
}
