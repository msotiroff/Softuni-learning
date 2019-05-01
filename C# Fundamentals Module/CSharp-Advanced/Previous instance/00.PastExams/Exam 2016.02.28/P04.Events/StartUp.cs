namespace P04.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text.RegularExpressions;

    class StartUp
    {
        static void Main(string[] args)
        {
            var validInputPattern = @"^\#(?<person>[A-Za-z]+)\:\s*\@(?<town>[A-Za-z]+)\s*(?<time>\d{1,2}\:\d{1,2})$";
            var regex = new Regex(validInputPattern);
            
            var allEvents = new Dictionary<string, Dictionary<string, List<DateTime>>>();

            var numberOfEvents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEvents; i++)
            {
                var currentEvent = Console.ReadLine();

                var match = regex.Match(currentEvent);

                if (match.Success)
                {
                    var town = match.Groups["town"].Value;
                    var person = match.Groups["person"].Value;
                    var time = match.Groups["time"].Value;

                    if (!IsTimeValid(time))
                    {
                        continue;
                    }

                    if (!allEvents.ContainsKey(town))
                    {
                        allEvents[town] = new Dictionary<string, List<DateTime>>();
                    }
                    if (!allEvents[town].ContainsKey(person))
                    {
                        allEvents[town][person] = new List<DateTime>();
                    }

                    var eventTime = DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);

                    allEvents[town][person].Add(eventTime);
                }
            }

            var townsToBePrinted = Console.ReadLine()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            var resultData = allEvents
                .Where(e => townsToBePrinted.Contains(e.Key))
                .ToDictionary(x => x.Key, x => x.Value
                    .ToDictionary(y => y.Key, y => y.Value));

            foreach (var town in resultData.OrderBy(t => t.Key))
            {
                Console.WriteLine($"{town.Key}:");

                var counter = 1;
                foreach (var person in town.Value.OrderBy(p => p.Key))
                {
                    var personEventsTimes = string.Join(", ", person
                        .Value
                        .OrderBy(t => t)
                        .Select(t => t.ToString("HH:mm")));

                    Console.WriteLine($"{counter++}. {person.Key} -> {personEventsTimes}");
                }
            }
        }

        private static bool IsTimeValid(string time)
        {
            var timeParams = time.Split(':');
            var hour = int.Parse(timeParams[0]);
            var minutes = int.Parse(timeParams[1]);

            return hour >= 0
                && hour < 24
                && minutes >= 0
                && minutes < 60;
        }
    }
}
