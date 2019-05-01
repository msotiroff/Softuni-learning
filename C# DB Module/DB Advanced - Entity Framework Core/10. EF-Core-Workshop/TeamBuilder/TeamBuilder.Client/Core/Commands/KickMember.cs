namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;

    public class KickMember
    {
        // <teamName> <username>
        public static string Execute(string[] commandArgs)
        {
            Check.CheckLenght(2, commandArgs);
            AuthenticationManager.Authorize();

            string teamName = commandArgs[0];
            string userName = commandArgs[1];
            ValidateCommand(teamName, userName);

            KickUser(teamName, userName);

            return $"User {userName} was kicked from {teamName}!";
        }

        private static void KickUser(string teamName, string userName)
        {
            using (var db = new TeamBuilderContext())
            {
                var team = db
                    .Teams
                    .First(t => t.Name == teamName);

                var userTobeKicked = db
                    .Users
                    .First(u => u.Username == userName);

                var membership = db
                    .UserTeams
                    .First(t => t.TeamId == team.Id && t.UserId == userTobeKicked.Id);

                db.UserTeams.Remove(membership);
                db.SaveChanges();
            }
        }

        private static void ValidateCommand(string teamName, string userName)
        {
            var currentUser = AuthenticationManager.GetCurrentUser();

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserExisting(userName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UserNotFound, userName));
            }

            if (!CommandHelper.IsMemberOfTeam(teamName, userName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.NotPartOfTeam, userName, teamName));
            }

            if (!CommandHelper.IsUserCreatorOfTeam(teamName, currentUser))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.NotAllowed));
            }

            using (var db = new TeamBuilderContext())
            {
                var userToBeKicked = db
                    .Users
                    .First(u => u.Username == userName);

                if (CommandHelper.IsUserCreatorOfTeam(teamName, userToBeKicked))
                {
                    throw new InvalidOperationException("Command not allowed. Use DisbandTeam instead.");
                }
            }
        }
    }
}
