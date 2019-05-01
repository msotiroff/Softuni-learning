namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class RegisterUserCommand
    {
        // RegisterUser <username> <password> <repeat-password> <firstName> <lastName> <age> <gender>
        public static string Execute(string[] inputArgs)
        {
            Check.CheckLenght(7, inputArgs);

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new ArgumentException(Constants.ErrorMessages.LogoutFirst);
            }

            string userName = inputArgs[0];
            ValidateUserName(userName);

            string password = inputArgs[1];
            ValidatePassword(password);

            string repeatedPassword = inputArgs[2];
            ValidateRepeatedPassword(repeatedPassword, password);

            string firstName = inputArgs[3];
            ValidateName(firstName);

            string lastName = inputArgs[4];
            ValidateName(lastName);

            int age = ValidateAge(inputArgs[5]);

            Gender gender;
            bool isGenderValid = Enum.TryParse(inputArgs[6], out gender);
            ValidateGender(isGenderValid);

            if (CommandHelper.IsUserExisting(userName))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.UsernameIsTaken, userName));
            }

            RegisterUser(userName, password, firstName, lastName, age, gender);

            return $"User {userName} was registered successfully";
        }

        private static int ValidateAge(string inputAge)
        {
            int age;
            if (int.TryParse(inputAge, out age))
            {
                if (age >= 0)
                {
                    return age;
                }
            }

            throw new ArgumentException(Constants.ErrorMessages.AgeNotValid);
        }

        private static void RegisterUser(string userName, string password, string firstName, string lastName, int age, Gender gender)
        {
            var user = new User()
            {
                Username = userName,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender
            };

            using (var db = new TeamBuilderContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        private static void ValidateGender(bool isGenderValid)
        {
            if (!isGenderValid)
            {
                throw new ArgumentException(Constants.ErrorMessages.GenderNotValid);
            }
        }

        private static void ValidateName(string name)
        {
            if (name.Length > 25)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidNameLenght);
            }
        }

        private static void ValidateRepeatedPassword(string repeatedPassword, string password)
        {
            if (repeatedPassword != password)
            {
                throw new ArgumentException(Constants.ErrorMessages.PasswordDoesNotMatch);
            }
        }

        private static void ValidatePassword(string password)
        {
            if (password.Length < Constants.MinPasswordLength 
                || password.Length > Constants.MaxPasswordLength 
                || !password.Any(p => char.IsUpper(p)
                || !password.Any(p1 => char.IsDigit(p1))))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, password));
            }
        }

        private static void ValidateUserName(string userName)
        {
            if (userName.Length < Constants.MinUsernameLength 
                || userName.Length > Constants.MaxUsernameLength)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid, userName));
            }
        }
    }
}
