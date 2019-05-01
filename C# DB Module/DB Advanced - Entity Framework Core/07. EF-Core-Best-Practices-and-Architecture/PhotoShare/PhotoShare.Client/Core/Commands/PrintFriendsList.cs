namespace PhotoShare.Client.Core.Commands
{
    using PhotoShare.Client.Utilities;
    using PhotoShare.Data;
    using System;
    using System.Linq;
    using System.Text;

    public class PrintFriendsListCommand 
    {
        // PrintFriendsList <username>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 2)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            var userName = commandArgs[1];

            // Logged/Non-Logged user can list friends of any user, so we don't check whether user is logged in or not

            using (var db = new PhotoShareContext())
            {
                var user = db
                    .Users
                    .FirstOrDefault(u => u.Username == userName);

                if (user == null)
                {
                    throw new ArgumentException($"User {userName} not found!");
                }

                var userFriends = db
                    .Friendships
                    .Where(f => f.UserId == user.Id)
                    .Select(f => f.Friend.Username)
                    .ToList();

                if (userFriends.Count == 0)
                {
                    return "No friends for this user. :(";
                }

                var friendsOutput = new StringBuilder();

                friendsOutput.AppendLine("Friends:");

                foreach (var friend in userFriends)
                {
                    friendsOutput.AppendLine($"-{friend}");
                }

                return friendsOutput.ToString().TrimEnd();
            }
        }
    }
}
