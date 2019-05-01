using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.RoliTheCoder
{
    class RoliTheCoder
    {
        static void Main(string[] args)
        {
            //        Store IDs         Store name   store names of
            //                          of event     participants
            Dictionary<string, Dictionary<string, List<string>>> eventsDataBase =
                new Dictionary<string, Dictionary<string, List<string>>>();

            Dictionary<string, List<string>> onlyNameAndParticipants = new Dictionary<string, List<string>>();

            string inputLine = Console.ReadLine();
            // Available input format: {id} #{eventName} @{participant1} @{participant2} … @{participantN}

            while (inputLine != "Time for Code")
            {
                string[] inputIdToken = inputLine
                    .Split('#')                         // Take the ID of input and remove whitespace around it.
                    .Select(x => x.Trim())
                    .ToArray();
                if (inputIdToken.Length < 2)
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                string currentID = inputIdToken[0];      // Current event ID.

                string eventAndParticipants = inputIdToken[1];

                string[] eventParameters = eventAndParticipants
                    .Split('@')                         // Take event name and string of all participants.
                    .Select(x => x.Trim())
                    .ToArray();

                string currentEventName = eventParameters[0];  // Current event name.

                List<string> currentParticipants = new List<string>();  // List of current participants.

                for (int i = 1; i < eventParameters.Length; i++)
                {
                    currentParticipants.Add(eventParameters[i]);
                }
                currentParticipants = currentParticipants.Distinct().ToList();

                if (!eventsDataBase.ContainsKey(currentID))
                {
                    eventsDataBase[currentID] = new Dictionary<string, List<string>>();
                    eventsDataBase[currentID][currentEventName] = new List<string>();
                    eventsDataBase[currentID][currentEventName].AddRange(currentParticipants);
                    eventsDataBase[currentID][currentEventName] = 
                        eventsDataBase[currentID][currentEventName].Distinct().ToList();

                    onlyNameAndParticipants[currentEventName] = new List<string>();
                    onlyNameAndParticipants[currentEventName].AddRange(currentParticipants);
                    onlyNameAndParticipants[currentEventName] = 
                        onlyNameAndParticipants[currentEventName].Distinct().ToList();
                }
                else
                {
                    if (eventsDataBase[currentID].ContainsKey(currentEventName))
                    {
                        eventsDataBase[currentID][currentEventName].AddRange(currentParticipants);
                        eventsDataBase[currentID][currentEventName] =
                            eventsDataBase[currentID][currentEventName].Distinct().ToList();

                        onlyNameAndParticipants[currentEventName].AddRange(currentParticipants);
                        onlyNameAndParticipants[currentEventName] = 
                            onlyNameAndParticipants[currentEventName].Distinct().ToList();
                    }
                }

                inputLine = Console.ReadLine();
            }

            var sorted = onlyNameAndParticipants
                .OrderByDescending(x => x.Value.Count())
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value.Count}");

                foreach (var participant in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"@{participant}");
                }
            }

            //  Following rows're not working properly, 
            //  when are there more than one event with the same count of participants.
            //  For example:
            
            //  2 #GameDevMeetup @sino @valyo
            //  1 #Beers @roli @trophon @alice
            //  1 #Beers2 @nakov @royal @ROYAL @ivo
            //  1 #Beers @roli @trophon @alice @sino
            //  3 #Rakia
            //  2 #GameDevMeetup @sinof @valyor
            //  Time for Code

            //foreach (var innerDict in eventsDataBase.Values.OrderByDescending(v => v.Values.Sum(p => p.Count)))
            //{
            //    foreach (var nameOfEvent in innerDict.OrderBy(f => f.Key))
            //    {
            //        Console.WriteLine($"{nameOfEvent.Key} - {innerDict[nameOfEvent.Key].Count}");
            //        foreach (var participant in innerDict[nameOfEvent.Key].OrderBy(x => x))
            //        {
            //            Console.WriteLine($"@{participant}");
            //        }
            //    }
            //}


        }
    }
}
