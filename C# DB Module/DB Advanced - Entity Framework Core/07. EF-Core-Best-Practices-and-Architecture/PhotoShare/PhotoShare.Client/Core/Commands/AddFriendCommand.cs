namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using PhotoShare.Data;
    using PhotoShare.Models;
    using PhotoShare.Client.Utilities;

    public class AddFriendCommand
    {
        // AddFriend <username1> <username2>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 3)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            var firstUsername = commandArgs[1];
            var secondUsername = commandArgs[2];

            using (var db = new PhotoShareContext())
            {
                ValidateUsers(firstUsername, secondUsername, db);

                CredentialsChecker.CheckUserCredentials(firstUsername);

                SendFriendshipRequest(firstUsername, secondUsername, db);

                return $"Friend {secondUsername} added to {firstUsername}";
            }
        }

        private static void SendFriendshipRequest(string firstUsername, string secondUsername, PhotoShareContext db)
        {
            var requestingUser = db
                .Users
                .First(u => u.Username == firstUsername);

            var userToResponse = db
                .Users
                .First(u => u.Username == secondUsername);

            var currentFriendShip = new Friendship()
            {
                UserId = requestingUser.Id,
                FriendId = userToResponse.Id
            };

            db.Friendships.Add(currentFriendShip);
            db.SaveChanges();
        }

        private static void ValidateUsers(string firstUsername, string secondUsername, PhotoShareContext db)
        {
            var firstUser = db
                .Users
                .FirstOrDefault(u => u.Username == firstUsername);

            if (firstUser == null)
            {
                throw new ArgumentException($"User {firstUsername} not found!");
            }

            var secondUser = db
                .Users
                .FirstOrDefault(u => u.Username == secondUsername);

            if (secondUser == null)
            {
                throw new ArgumentException($"User {secondUsername} not found!");
            }

            var areTheyFrends = db
                .Friendships
                .Any(f => f.UserId == firstUser.Id && f.FriendId == secondUser.Id);

            if (areTheyFrends)
            {
                throw new InvalidOperationException($"{secondUsername} is already a friend to {firstUsername}");
            }
        }
    }
}
