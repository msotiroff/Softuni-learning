using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.RoliTheCoder
{
    class RoliTheCoder
    {
        static void Main(string[] args)
        {
            //          ID              EventName    Participants
            Dictionary<string, Dictionary<string, List<string>>> allEventsAndIDs =
                new Dictionary<string, Dictionary<string, List<string>>>();

            Dictionary<string, List<string>> eventsAndParticipants =
                new Dictionary<string, List<string>>();

            Regex getInputData = new Regex(@"(?<ID>\d+)\s+\#(?<EventName>\w+)\s*(?<Players>[A-Za-z'-@\s]*)");

            string inputLine = Console.ReadLine();

            while (inputLine != "Time for Code")
            {
                var matchParameters = getInputData.Match(inputLine);

                if (matchParameters.Success)
                {
                    string currentID = matchParameters.Groups["ID"].Value.ToString();
                    string currentEventName = matchParameters.Groups["EventName"].Value.ToString();
                    List<string> currentParticipants = matchParameters
                        .Groups["Players"].Value.ToString()
                        .Split(new[] { '@', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(p => p.Trim())
                        .ToList();

                    if (!allEventsAndIDs.ContainsKey(currentID))
                    {
                        allEventsAndIDs[currentID] = new Dictionary<string, List<string>>();
                        allEventsAndIDs[currentID][currentEventName] = new List<string>();
                        allEventsAndIDs[currentID][currentEventName].AddRange(currentParticipants);
                        allEventsAndIDs[currentID][currentEventName] =
                            allEventsAndIDs[currentID][currentEventName].Distinct().ToList();



                        eventsAndParticipants[currentEventName] = new List<string>();
                        eventsAndParticipants[currentEventName].AddRange(currentParticipants);
                        eventsAndParticipants[currentEventName] =
                            eventsAndParticipants[currentEventName].Distinct().ToList();

                    }
                    else
                    {
                        if (allEventsAndIDs[currentID].ContainsKey(currentEventName))
                        {
                            allEventsAndIDs[currentID][currentEventName].AddRange(currentParticipants);
                            allEventsAndIDs[currentID][currentEventName] =
                                allEventsAndIDs[currentID][currentEventName].Distinct().ToList();

                            eventsAndParticipants[currentEventName].AddRange(currentParticipants);
                            eventsAndParticipants[currentEventName] =
                                eventsAndParticipants[currentEventName].Distinct().ToList();
                        }
                    }
                    

                }


                inputLine = Console.ReadLine();
            }

            foreach (var @event in eventsAndParticipants.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key))
            {
                Console.WriteLine($"{@event.Key} - {@event.Value.Count}");

                foreach (var participant in @event.Value.OrderBy(p => p))
                {
                    Console.WriteLine($"@{participant}");
                }
            }

        }
    }
}
