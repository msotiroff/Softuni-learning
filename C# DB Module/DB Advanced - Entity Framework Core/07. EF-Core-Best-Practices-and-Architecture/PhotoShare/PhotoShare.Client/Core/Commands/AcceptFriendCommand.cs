namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using PhotoShare.Data;
    using PhotoShare.Client.Utilities;

    public class AcceptFriendCommand
    {
        // AcceptFriend <username1> <username2>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 3)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            var inputUserToAccept = commandArgs[1];
            var inputUserSentRequest = commandArgs[2];


            //CredentialsChecker.CheckUserCredentials(inputUserToAccept);

            using (var db = new PhotoShareContext())
            {
                ValidateUsers(inputUserToAccept, inputUserSentRequest, db);

                AcceptFriendship(inputUserToAccept, inputUserSentRequest, db);

                return $"{inputUserToAccept} accepted {inputUserSentRequest} as a friend";
            }
        }

        private static void AcceptFriendship(string inputUserToAccept, string inputUserSentRequest, PhotoShareContext db)
        {
            
        }

        private static void ValidateUsers(string inputUserToAccept, string inputUserSentRequest, PhotoShareContext db)
        {
            var userToAccept = db
                .Users
                .FirstOrDefault(u => u.Username == inputUserToAccept);

            if (userToAccept == null)
            {
                throw new ArgumentException($"{inputUserToAccept} not found!");
            }

            var userSentRequest = db
                .Users
                .FirstOrDefault(u => u.Username == inputUserSentRequest);

            if (userSentRequest == null)
            {
                throw new ArgumentException($"{inputUserSentRequest} not found!");
            }

            var areTheyAlreadyFriends = db
                .Friendships
                .Any(f => f.UserId == userToAccept.Id && f.FriendId == userSentRequest.Id);

            if (areTheyAlreadyFriends)
            {
                throw new InvalidOperationException($"{inputUserSentRequest} is already a friend to {inputUserToAccept}");
            }

            var isThereFriendRequest = db
                .Friendships
                .Any(f => f.UserId == userSentRequest.Id && f.FriendId == userToAccept.Id);

            if (!isThereFriendRequest)
            {
                throw new InvalidOperationException($"{inputUserSentRequest} has not added {inputUserToAccept} as a friend");
            }
        }
    }
}
