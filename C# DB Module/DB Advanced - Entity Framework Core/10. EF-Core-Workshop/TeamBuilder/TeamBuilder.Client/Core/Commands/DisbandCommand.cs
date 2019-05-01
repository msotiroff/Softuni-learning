namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;

    public class DisbandCommand
    {
        // <teamName>
        public static string Execute(string[] commandArgs)
        {
            Check.CheckLenght(1, commandArgs);
            AuthenticationManager.Authorize();

            string teamName = commandArgs[0];
            ValidateCommand(teamName);

            DeleteTeam(teamName);

            return $"{teamName} has disbanded!";
        }

        private static void DeleteTeam(string teamName)
        {
            using (var db = new TeamBuilderContext())
            {
                var teamToBeDeleted = db
                    .Teams
                    .First(t => t.Name == teamName);

                var membershipsToBeDeleted = db
                    .UserTeams
                    .Where(ut => ut.TeamId == teamToBeDeleted.Id)
                    .ToList();

                var eventsToBeDeleted = db
                    .TeamEvents
                    .Where(te => te.TeamId == teamToBeDeleted.Id)
                    .ToList();

                var invitationsToBeDeleted = db
                    .Invitations
                    .Where(i => i.TeamId == teamToBeDeleted.Id)
                    .ToList();

                db.UserTeams.RemoveRange(membershipsToBeDeleted);
                db.TeamEvents.RemoveRange(eventsToBeDeleted);
                db.Invitations.RemoveRange(invitationsToBeDeleted);
                db.Teams.Remove(teamToBeDeleted);

                db.SaveChanges();
            }
        }

        private static void ValidateCommand(string teamName)
        {
            var currentUser = AuthenticationManager.GetCurrentUser();

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserCreatorOfTeam(teamName, currentUser))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }
        }
    }
}
