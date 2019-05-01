namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Globalization;
    using System.Linq;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class CreateEventInternalCommand
    {
        // CreateEvent <name> <description> <startDate> <endDate>
        public static string Execute(string[] commandArgs)
        {
            if (commandArgs.Length < 6)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidArgumentsCount);
            }

            int inputLenght = commandArgs.Length;

            var currentUser = AuthenticationManager.GetCurrentUser();

            string eventName = commandArgs[0];
            ValidateName(eventName);

            string description = string.Join(" ", commandArgs.Skip(1).Take(inputLenght - 5));
            ValidateDescription(description);

            DateTime startDate;
            startDate = ValidateDate($"{commandArgs[inputLenght - 4]} {commandArgs[inputLenght - 3]}");

            DateTime endDate = ValidateDate($"{commandArgs[inputLenght - 2]} {commandArgs[inputLenght - 1]}");
            if (endDate <= startDate)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidEndDate);
            }

            CreateCurrentEvent(currentUser, eventName, description, startDate, endDate);

            return $"Event {eventName} was created successfully!";
        }

        private static void ValidateDescription(string description)
        {
            if (description.Length > 32)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidDescription, 32));
            }
        }

        private static void CreateCurrentEvent(User currentUser, string eventName, string description, DateTime startDate, DateTime endDate)
        {
            var currentEvent = new Event()
            {
                Name = eventName,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                CreatorId = currentUser.Id
            };

            using (var db = new TeamBuilderContext())
            {
                ValidateEvent(currentEvent, db);

                db.Events.Add(currentEvent);
                db.SaveChanges();
            }
        }

        private static void ValidateEvent(Event currentEvent, TeamBuilderContext db)
        {
            // Checks if name and startdate of current event are already added to database, couse by condition, Events' names are not unique.
            var isEventExisting = db
                .Events
                .Any(e => e.Name == currentEvent.Name && e.StartDate == currentEvent.StartDate);

            if (isEventExisting)
            {
                throw new InvalidOperationException(Constants.ErrorMessages.EventAlreadyExist);
            }
        }

        private static DateTime ValidateDate(string date)
        {
            try
            {
                DateTime startDate = DateTime.ParseExact(date, Constants.DateTimeFormat, CultureInfo.InvariantCulture);

                return startDate;
            }
            catch (Exception)
            {
                throw new FormatException(Constants.ErrorMessages.InvalidDateFormat);
            }
        }

        private static void ValidateName(string eventName)
        {
            if (eventName.Length > 25)
            {
                throw new ArgumentException("Event name should be no longer than 25 symbols");
            }
        }
    }
}
