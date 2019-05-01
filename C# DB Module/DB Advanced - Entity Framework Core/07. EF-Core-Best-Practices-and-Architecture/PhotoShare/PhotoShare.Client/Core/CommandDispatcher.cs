namespace PhotoShare.Client.Core
{
    using System;
    using Core.Commands;

    public class CommandDispatcher
    {
        public string DispatchCommand(string[] commandParameters)
        {
            string output = string.Empty;

            var mainCommand = commandParameters[0];

            switch (mainCommand)
            {
                case "RegisterUser":
                    output = RegisterUserCommand.Execute(commandParameters);
                    break;
                case "Login":
                    output = LoginCommand.Execute(commandParameters);
                    break;
                case "Logout":
                    output = LogoutCommand.Execute(commandParameters);
                    break;
                case "AddTown":
                    output = AddTownCommand.Execute(commandParameters);
                    break;
                case "ModifyUser":
                    output = ModifyUserCommand.Execute(commandParameters);
                    break;
                case "DeleteUser":
                    output = DeleteUser.Execute(commandParameters);
                    break;
                case "AddTag":
                    output = AddTagCommand.Execute(commandParameters);
                    break;
                case "CreateAlbum":
                    output = CreateAlbumCommand.Execute(commandParameters);
                    break;
                case "AddTagTo":
                    output = AddTagToCommand.Execute(commandParameters);
                    break;
                case "AddFriend":
                    output = AddFriendCommand.Execute(commandParameters);
                    break;
                case "AcceptFriend":
                    output = AcceptFriendCommand.Execute(commandParameters);
                    break;
                case "MakeFriends":
                    output = MakeFriendsCommand.Execute(commandParameters);
                    break;
                case "ListFriends":
                    output = PrintFriendsListCommand.Execute(commandParameters);
                    break;
                case "ShareAlbum":
                    output = ShareAlbumCommand.Execute(commandParameters);
                    break;
                case "UploadPicture":
                    output = UploadPictureCommand.Execute(commandParameters);
                    break;
                case "Exit":
                    ExitCommand.Execute();
                    break;

                default:
                    throw new InvalidOperationException($"Command {mainCommand} not valid!");
            }

            return output;
        }
    }
}
