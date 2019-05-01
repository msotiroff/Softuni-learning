namespace TeamBuilder.Client.Utilities
{
    using System.Linq;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            var result = false;

            using (var db = new TeamBuilderContext())
            {
                if (db.Teams.Any(t => t.Name == teamName))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsUserExisting(string username)
        {
            var result = false;

            using (var db = new TeamBuilderContext())
            {
                if (db.Users.Any(u => u.Username == username))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsInviteExisting(string teamName, User user)
        {
            var result = false;

            using (var db = new TeamBuilderContext())
            {
                if (db.Invitations
                    .Any(i => i.Team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            var result = false;

            using (var db = new TeamBuilderContext())
            {
                if (db.Teams.First(t => t.Name == teamName).CreatorId == user.Id)
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            var result = false;

            using (var db = new TeamBuilderContext())
            {
                if (db.Events.First(e => e.Name == eventName).CreatorId == user.Id)
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            var result = false;

            using (var db = new TeamBuilderContext())
            {
                if (db.UserTeams.Any(ut => ut.Team.Name == teamName && ut.User.Username == username))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsEventExisting(string eventName)
        {
            var result = false;

            using (var db = new TeamBuilderContext())
            {
                if (db.Events.Any(e => e.Name == eventName))
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool isTeamAlreadyAddedToEvent(string teamName, string eventName)
        {
            var result = false;

            using (var db = new TeamBuilderContext())
            {
                if (db.TeamEvents.Any(te => te.Event.Name == eventName && te.Team.Name == teamName))
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
