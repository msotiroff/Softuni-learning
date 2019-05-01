namespace TeamBuilder.Client.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class InviteToTeamCommand
    {
        // <teamName> <username>
        public static string Execute(string[] commandArgs)
        {
            Check.CheckLenght(2, commandArgs);
            AuthenticationManager.Authorize();

            string teamName = commandArgs[0];
            string userToInviteName = commandArgs[1];

            ValidateInvitation(userToInviteName, teamName);

            CreateInvitation(teamName, userToInviteName);

            return $"Team {teamName} invited {userToInviteName}!";
        }

        private static void ValidateInvitation(string userToInviteName, string teamName)
        {
            using (var db = new TeamBuilderContext())
            {
                var userToInvite = db
                    .Users
                    .FirstOrDefault(u => u.Username == userToInviteName);

                var team = db
                    .Teams
                    .FirstOrDefault(t => t.Name == teamName);

                if (userToInvite == null || team == null)
                {
                    throw new ArgumentException(Constants.ErrorMessages.TeamOrUserNotExist);
                }

                if (db.Invitations.Any(i => i.InvitedUserId == userToInvite.Id && i.TeamId == team.Id))
                {
                    throw new InvalidOperationException(Constants.ErrorMessages.InviteIsAlreadySent);
                }

                var loggedUser = AuthenticationManager.GetCurrentUser();
                var isUserCreatorOfTeam = CommandHelper.IsUserCreatorOfTeam(team.Name, loggedUser);
                var isUserPartOfTeam = CommandHelper.IsMemberOfTeam(team.Name, loggedUser.Username);
                var isUserToInviteAlreadyMember = CommandHelper.IsMemberOfTeam(team.Name, userToInvite.Username);

                if (!isUserCreatorOfTeam || !isUserPartOfTeam || isUserToInviteAlreadyMember)
                {
                    throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
                }
            }
        }

        private static void CreateInvitation(string teamName, string userToInviteName)
        {
            using (var db = new TeamBuilderContext())
            {
                var userToInvite = db
                    .Users
                    .FirstOrDefault(u => u.Username == userToInviteName);

                var team = db
                    .Teams
                    .Include(t => t.UserTeams)
                    .FirstOrDefault(t => t.Name == teamName);

                var currentInvitation = new Invitation()
                {
                    InvitedUserId = userToInvite.Id,
                    TeamId = team.Id
                };

                db.Invitations.Add(currentInvitation);
                db.SaveChanges();
            }
        }
    }
}
