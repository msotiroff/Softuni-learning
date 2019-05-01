namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;

    public class ShowTeamCommand
    {
        public static string Execute(string[] commandArgs)
        {
            Check.CheckLenght(1, commandArgs);

            string teamName = commandArgs[0];
            ValidateEvent(teamName);

            string result = GetTeamDetails(teamName);

            return result;
        }

        private static string GetTeamDetails(string teamName)
        {
            var result = new StringBuilder();

            using (var db = new TeamBuilderContext())
            {
                var teamDetails = db
                    .Teams
                    .Where(t => t.Name == teamName)
                    .Select(t => new
                    {
                        Name = t.Name,
                        Acronym = t.Acronym,
                        Members = t.UserTeams
                        .Select(ut => new
                        {
                            UserName = ut.User.Username
                        })
                        .ToArray()
                    })
                    .First();

                result.AppendLine($"{teamDetails.Name} {teamDetails.Acronym}");
                if (teamDetails.Members.Length > 0)
                {
                    result.AppendLine("Members:");

                    foreach (var member in teamDetails.Members)
                    {
                        result.AppendLine($"--{member.UserName}");
                    }
                }
            }

            return result.ToString().TrimEnd();
        }

        private static void ValidateEvent(string teamName)
        {
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }
        }
    }
}
