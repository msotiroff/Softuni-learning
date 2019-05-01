namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using PhotoShare.Models;
    using PhotoShare.Data;
    using PhotoShare.Client.Utilities;

    public class RegisterUserCommand
    {
        // RegisterUser <username> <password> <repeat-password> <email>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 5)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            // Checks whether it has a logged in user!
            CredentialsChecker.CheckLogout();

            string username = commandArgs[1];
            string password = commandArgs[2];
            string repeatPassword = commandArgs[3];
            string email = commandArgs[4];

            using (var db = new PhotoShareContext())
            {
                var isUserNameTaken = db
                    .Users
                    .Any(u => u.Username == username);

                if (isUserNameTaken)
                {
                    throw new InvalidOperationException($"Username {username} is already taken!");
                }
            }

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match!");
            }
            
            User user = new User
            {
                Username = username,
                Password = password,
                Email = email,
                IsDeleted = false,
                RegisteredOn = DateTime.Now
            };
            
            using (var db = new PhotoShareContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return $"User {user.Username} was registered successfully!";
        }
    }
}
