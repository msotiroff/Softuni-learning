namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class AddTeamToCommand
    {
        // <eventName> <teamName>
        public static string Execute(string[] commandArgs)
        {
            Check.CheckLenght(2, commandArgs);
            AuthenticationManager.Authorize();

            string eventName = commandArgs[0];
            string teamName = commandArgs[1];
            ValidateCommand(eventName, teamName);

            AddTeamTo(eventName, teamName);

            return $"Team {teamName} added for {eventName}!";
        }

        private static void AddTeamTo(string eventName, string teamName)
        {
            using (var db = new TeamBuilderContext())
            {
                var events = db
                    .Events
                    .Where(e => e.Name == eventName)
                    .ToList();

                var eventId = default(int);

                if (events.Count > 1)
                {
                    DateTime? latestDate = events
                        .Where(e => e.StartDate.HasValue)
                        .Max(e => e.StartDate)
                        .Value;

                    eventId = events
                        .Single(e => e.StartDate == latestDate)
                        .Id;
                }
                else
                {
                    eventId = events.First().Id;
                }

                var teamId = db
                    .Teams
                    .First(t => t.Name == teamName)
                    .Id;

                var currentTeamEvent = new TeamEvent()
                {
                    EventId = eventId,
                    TeamId = teamId
                };

                db.TeamEvents.Add(currentTeamEvent);
                db.SaveChanges();
            }
        }

        private static void ValidateCommand(string eventName, string teamName)
        {
            var currentUser = AuthenticationManager.GetCurrentUser();

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsUserCreatorOfEvent(eventName, currentUser))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            if (CommandHelper.isTeamAlreadyAddedToEvent(teamName, eventName))
            {
                throw new InvalidOperationException("Cannot add same team twice!");
            }
        }
    }
}
