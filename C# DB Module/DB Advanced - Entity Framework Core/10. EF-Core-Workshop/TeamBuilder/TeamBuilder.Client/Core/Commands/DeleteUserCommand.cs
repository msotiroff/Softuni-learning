namespace TeamBuilder.Client.Core.Commands
{
    using System.Linq;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;

    public class DeleteUserCommand
    {
        public static string Execute(string[] commandArgs)
        {
            Check.CheckLenght(0, commandArgs);

            AuthenticationManager.Authorize();

            var currentUser = AuthenticationManager.GetCurrentUser();

            DeleteUser(currentUser.Id);

            return $"User {currentUser.Username} was deleted successfully!";
        }

        private static void DeleteUser(int id)
        {
            using (var db = new TeamBuilderContext())
            {
                var userToBeDeleted = db
                    .Users
                    .First(u => u.Id == id);

                userToBeDeleted.IsDeleted = true;

                db.SaveChanges();
            }

            AuthenticationManager.Logout();
        }
    }
}
