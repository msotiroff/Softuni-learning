namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Data;
    using PhotoShare.Client.Utilities;

    public class DeleteUser
    {
        // DeleteUser <username>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 2)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            string userName = commandArgs[1];

            // Logged user can delete only himself/herself
            CredentialsChecker.CheckUserCredentials(userName);

            using (var db = new PhotoShareContext())
            {
                var userToBeDeleted = db
                    .Users
                    .FirstOrDefault(u => u.Username == userName);

                if (userToBeDeleted == null)
                {
                    throw new ArgumentException($"User with {userName} was not found!");
                }

                if (userToBeDeleted.IsDeleted == true)
                {
                    throw new InvalidOperationException($"User {userName} is already deleted!");
                }

                // Delete User by username (only mark him as inactive)
                userToBeDeleted.IsDeleted = true;
                db.SaveChanges();

                return $"User {userName} was deleted from the database!";
            }
        }
    }
}
