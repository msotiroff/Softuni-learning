namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class DeclineInvitartionCommand
    {
        // <teamName>
        public static string Execute(string[] commandArgs)
        {
            Check.CheckLenght(1, commandArgs);
            AuthenticationManager.Authorize();

            string teamName = commandArgs[0];
            ValidateTeamName(teamName);

            var currentUser = AuthenticationManager.GetCurrentUser();
            DeclineInvitation(teamName, currentUser);
            
            return $"Invite from {teamName} declined.";
        }

        private static void DeclineInvitation(string teamName, User currentUser)
        {
            using (var db = new TeamBuilderContext())
            {
                var teamId = db
                    .Teams
                    .First(t => t.Name == teamName)
                    .Id;

                var invitationToMarkAsInactive = db
                   .Invitations
                   .First(i => i.TeamId == teamId && i.InvitedUserId == currentUser.Id);

                invitationToMarkAsInactive.IsActive = false;
                db.SaveChanges();
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
