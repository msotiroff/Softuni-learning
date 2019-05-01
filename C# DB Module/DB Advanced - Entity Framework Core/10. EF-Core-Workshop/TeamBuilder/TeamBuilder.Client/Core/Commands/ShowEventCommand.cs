namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;

    public class ShowEventCommand
    {
        // <eventName>
        public static string Execute(string[] commandArgs)
        {
            Check.CheckLenght(1, commandArgs);

            string eventName = commandArgs[0];
            ValidateEvent(eventName);

            string result = GetEventDetails(eventName);

            return result;
        }

        private static string GetEventDetails(string eventName)
        {
            var result = new StringBuilder();

            using (var db = new TeamBuilderContext())
            {
                /* 
                 * We may have multiple events with the same name,
                 * so we get all the events with the given name!
                 */

                var eventsDetails = db
                    .Events
                    .Where(e => e.Name == eventName)
                    .Select(e => new
                    {
                        EventName = e.Name,
                        StartDate = e.StartDate,
                        EndDate = e.EndDate,
                        Description = e.Description,
                        Teams = e.ParticipatingTeamEvents
                            .Select(te => new
                            {
                                TeamName = te.Team.Name
                            })
                            .ToArray()
                    })
                    .ToArray();

                foreach (var currentEvent in eventsDetails)
                {
                    string startDate = string.Empty;
                    string endDate = string.Empty;

                    if (currentEvent.StartDate != null)
                    {
                        startDate = " " + currentEvent.StartDate.Value.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    }
                    if (currentEvent.EndDate != null)
                    {
                        endDate = " " + currentEvent.EndDate.Value.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    }
                    
                    result.AppendLine($"{currentEvent.EventName}{startDate}{endDate}");

                    if (currentEvent.Description != null)
                    {
                        result.AppendLine(currentEvent.Description);
                    }

                    if (currentEvent.Teams.Length > 0)
                    {
                        result.AppendLine("Teams:");

                        foreach (var team in currentEvent.Teams)
                        {
                            result.AppendLine($"-{team.TeamName}");
                        }
                    }
                }
            }
            
            return result.ToString().TrimEnd();
        }

        private static void ValidateEvent(string eventName)
        {
            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }
        }
    }
}
