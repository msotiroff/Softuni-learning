namespace TeamBuilder.Client.Core.Commands
{
    using TeamBuilder.Client.Utilities;

    public class LogoutCommand
    {
        public static string Execute(string[] commandArgs)
        {
            Check.CheckLenght(0, commandArgs);

            var currentUser = AuthenticationManager.GetCurrentUser();

            AuthenticationManager.Logout();

            return $"User {currentUser.Username} successfully logged out!";
        }
    }
}