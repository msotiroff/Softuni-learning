namespace P04.BestLecturesSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StartUp
    {
        public static void Main()
        {
            var allEvents = new List<Event>();

            var pattern = @"(?<lecture>\w+):\s*(?<start>\d+)\s*\-\s*(?<end>\d+)";

            var lecturesCount = int.Parse(Console.ReadLine().Split().Last());

            for (int i = 0; i < lecturesCount; i++)
            {
                var currentLectureInput = Console.ReadLine();

                var match = Regex.Match(currentLectureInput, pattern);

                if (match.Success)
                {
                    var lecture = match.Groups["lecture"].Value;
                    var startTime = int.Parse(match.Groups["start"].Value);
                    var endTime = int.Parse(match.Groups["end"].Value);

                    var currentEvent = new Event(lecture, startTime, endTime);

                    allEvents.Add(currentEvent);
                }
            }

            var resultSetOfEvents = new List<Event>();

            while (allEvents.Count > 0)
            {
                var currentEvent = allEvents
                    .OrderBy(e => e.EndTime)
                    .FirstOrDefault();

                resultSetOfEvents.Add(currentEvent);

                allEvents.RemoveAll(e => e.StartTime < currentEvent.EndTime);
            }

            Console.WriteLine($"Lectures ({resultSetOfEvents.Count}):");
            resultSetOfEvents
                .ForEach(e => Console.WriteLine(e));
        }
    }
}
