namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;

    public class LoginCommand
    {
        // Login <username> <password>
        public static string Execute(string[] commandArgs)
        {
            Check.CheckLenght(2, commandArgs);

            string userName = commandArgs[0];
            string password = commandArgs[1];

            if (AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException(Constants.ErrorMessages.LogoutFirst);
            }

            using (var db = new TeamBuilderContext())
            {
                var user = db
                    .Users
                    .FirstOrDefault(u => u.Username == userName && u.Password == password && !u.IsDeleted);

                if (user == null)
                {
                    throw new ArgumentException(Constants.ErrorMessages.UserOrPasswordIsInvalid);
                }

                AuthenticationManager.Login(user);
            }

            return $"User {userName} successfully logged in!";
        }
    }
}
