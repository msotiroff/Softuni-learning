namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Data;
    using System;
    using System.Linq;

    public class LoginCommand
    {
        // Login <username> <password>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 3)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            var userName = commandArgs[1];
            var password = commandArgs[2];

            using (var db = new PhotoShareContext())
            {
                CheckCredentials(userName, password, db);

                var currentUser = db
                .Users
                .FirstOrDefault(u => u.Username == userName);

                var loggedUser = Session.User;

                if (loggedUser != null)
                {
                    if (loggedUser.Id == currentUser.Id)
                    {
                        throw new ArgumentException("You should logout first!");
                    }
                }

                currentUser.LastTimeLoggedIn = DateTime.Now;
                db.SaveChanges();

                Session.User = currentUser;

                return $"User {userName} successfully logged in!";
            }
        }

        private static void CheckCredentials(string userName, string password, PhotoShareContext db)
        {
            var user = db
                .Users
                .FirstOrDefault(u => u.Username == userName);

            if (user == null || user.IsDeleted.Value == true)
            {
                throw new ArgumentException($"Invalid username {userName}!");
            }

            var passwordMatch = db
                .Users
                .First(u => u.Username == userName)
                .Password == password;

            if (!passwordMatch)
            {
                throw new InvalidOperationException("Wrong password!");
            }
        }
    }
}
