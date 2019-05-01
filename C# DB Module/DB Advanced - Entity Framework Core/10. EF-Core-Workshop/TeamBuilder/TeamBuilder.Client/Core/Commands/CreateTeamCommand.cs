namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class CreateTeamCommand
    {
        // <name> <acronym> <description>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length < 2)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidArgumentsCount);
            }

            AuthenticationManager.Authorize();

            string teamName = commandArgs[0];
            ValidateName(teamName);

            string acronym = commandArgs[1];
            ValidateAcronym(acronym);

            string description = null;
            if (commandArgs.Length > 2)
            {
                description = string.Join(" ", commandArgs.Skip(2));
                ValidateDescription(description);
            }

            CreateTeam(teamName, acronym, description);

            return $"Team {teamName} successfully created!";
        }

        private static void CreateTeam(string teamName, string acronym, string description)
        {
            var currentTeam = new Team()
            {
                Name = teamName,
                Acronym = acronym,
                Description = description,
                CreatorId = AuthenticationManager.GetCurrentUser().Id
            };

            using (var db = new TeamBuilderContext())
            {
                db.Teams.Add(currentTeam);
                db.SaveChanges();

                var newTeamId = db
                    .Teams
                    .First(t => t.Name == teamName)
                    .Id;

                db.UserTeams.Add(new UserTeam()
                {
                    UserId = AuthenticationManager.GetCurrentUser().Id,
                    TeamId = newTeamId
                });
                db.SaveChanges();
            }

            
        }

        private static void ValidateDescription(string description)
        {
            if (description.Length > 32)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidDescription, 32));
            }
        }

        private static void ValidateAcronym(string acronym)
        {
            if (acronym.Length != 3)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidAcronym);
            }
        }

        private static void ValidateName(string teamName)
        {
            if (teamName.Length > 25)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidTeamName);
            }

            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamExists, teamName));
            }
        }
    }
}
