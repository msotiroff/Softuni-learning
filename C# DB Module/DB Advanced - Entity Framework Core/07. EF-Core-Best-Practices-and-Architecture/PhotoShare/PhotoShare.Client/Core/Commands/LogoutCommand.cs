namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class LogoutCommand
    {
        // Logout
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length > 1)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            if (Session.User == null)
            {
                throw new InvalidOperationException("You should log in first in order to logout.");
            }

            var loggedInUser = Session.User.Username;

            Session.User = null;
            return $"User {loggedInUser} successfully logged out!";
        }
    }
}
