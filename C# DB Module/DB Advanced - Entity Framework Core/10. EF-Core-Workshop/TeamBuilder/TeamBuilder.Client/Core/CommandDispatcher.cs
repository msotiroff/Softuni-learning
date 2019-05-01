namespace TeamBuilder.Client.Core
{
    using System;
    using System.Linq;
    using TeamBuilder.Client.Core.Commands;

    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty; ;

            string[] inputArgs = input
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string commandName = inputArgs.Length > 0 ? inputArgs[0].ToLower() : string.Empty;
            inputArgs = inputArgs.Skip(1).ToArray();

            switch (commandName)
            {
                case "exit":
                    result = ExitCommand.Execute(inputArgs);
                    break;
                case "registeruser":
                    result = RegisterUserCommand.Execute(inputArgs);
                    break;
                case "login":
                    result = LoginCommand.Execute(inputArgs);
                    break;
                case "logout":
                    result = LogoutCommand.Execute(inputArgs);
                    break;
                case "deleteuser":
                    result = DeleteUserCommand.Execute(inputArgs);
                    break;
                case "createevent":
                    result = CreateEventInternalCommand.Execute(inputArgs);
                    break;
                case "createteam":
                    result = CreateTeamCommand.Execute(inputArgs);
                    break;
                case "invitetoteam":
                    result = InviteToTeamCommand.Execute(inputArgs);
                    break;
                case "acceptinvite":
                    result = AcceptInviteCommand.Execute(inputArgs);
                    break;
                case "declineinvite":
                    result = DeclineInvitartionCommand.Execute(inputArgs);
                    break;
                case "kickmember":
                    result = KickMemberInternalCommand.Execute(inputArgs);
                    break;
                case "disband":
                    result = DisbandCommand.Execute(inputArgs);
                    break;
                case "addteamto":
                    result = AddTeamToCommand.Execute(inputArgs);
                    break;
                case "showevent":
                    result = ShowEventCommand.Execute(inputArgs);
                    break;
                case "showteam":
                    result = ShowTeamCommand.Execute(inputArgs);
                    break;
                default:
                    throw new NotSupportedException($"Command {commandName} not supported!");
            }

            return result;
        }
    }
}
