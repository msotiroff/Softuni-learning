namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class AcceptInviteCommand
    {
        // <teamName>
        public static string Execute(string[] commandArgs)
        {
            Check.CheckLenght(1, commandArgs);
            AuthenticationManager.Authorize();

            string teamName = commandArgs[0];
            ValidateTeamName(teamName);

            var currentUser = AuthenticationManager.GetCurrentUser();
            ValidateInvitation(teamName, currentUser);

            AcceptInvitation(teamName, currentUser);

            return $"User {currentUser.Username} joined team {teamName}!";
        }

        private static void AcceptInvitation(string teamName, User currentUser)
        {
            using (var db = new TeamBuilderContext())
            {
                var teamId = db
                    .Teams
                    .First(t => t.Name == teamName)
                    .Id;

                var newMembership = new UserTeam()
                {
                    TeamId = teamId,
                    UserId = currentUser.Id
                };

                db.UserTeams.Add(newMembership);
                db.SaveChanges();

                var invitationToMarkAsInactive = db
                    .Invitations
                    .First(i => i.TeamId == teamId && i.InvitedUserId == currentUser.Id);

                invitationToMarkAsInactive.IsActive = false;
                db.SaveChanges();
            }

            
        }

        private static void ValidateInvitation(string teamName, Models.User currentUser)
        {
            var isInviteExisting = CommandHelper.IsInviteExisting(teamName, currentUser);

            if (!isInviteExisting)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound, teamName));
            }
        }

        private static void ValidateTeamName(string teamName)
        {
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
        }
    }
}
