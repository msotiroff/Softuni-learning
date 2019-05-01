namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class MakeFriendsCommand
    {
        // MakeFriends <username1> <username2>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length != 3)
            {
                throw new InvalidOperationException($"Command parameters count not valid!");
            }

            var firstUserName = commandArgs[1];
            var secondUserName = commandArgs[2];
            
            string requestFriendShip = AddFriendCommand.Execute(new string[] { "AddFriend", firstUserName, secondUserName });

            string acceptFriendShip = AcceptFriendCommand.Execute(new string[] { "AcceptFriend", secondUserName, firstUserName });

            // Friendship means that first user has sent friend request to second user, an second user has accepted it, 
            // i.e. in the database will exists two objects of type "Friendship" with the following values: 
            // { firstUser.Id, secondUser.Id} and {secondUser.Id, firstUser.Id}

            return $"Friendship was made successfully!";
        }
    }
}
