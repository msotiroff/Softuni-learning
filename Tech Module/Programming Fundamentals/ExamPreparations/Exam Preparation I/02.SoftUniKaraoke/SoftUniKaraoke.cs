using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SoftUniKaraoke
{
    class SoftUniKaraoke
    {
        static void Main(string[] args)
        {
            string[] availableSingers = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] availableSongs = Console.ReadLine()
                .Split(',')
                .Select(x => x.Trim())
                .ToArray();

            Dictionary<string, SortedSet<string>> awardWinners = 
                new Dictionary<string, SortedSet<string>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "dawn")
            {
                string[] inputParameters = inputLine
                    .Split(',')
                    .Select(x => x.Trim())
                    .ToArray();
                string currentSinger = inputParameters[0];
                string currentSong = inputParameters[1];
                string currentAward = inputParameters[2];

                if (availableSingers.Contains(currentSinger) && availableSongs.Contains(currentSong))
                {
                    if (!awardWinners.ContainsKey(currentSinger))
                    {
                        awardWinners[currentSinger] = new SortedSet<string>();
                    }

                    awardWinners[currentSinger].Add(currentAward);
                }

                inputLine = Console.ReadLine();
            }

            var sortedAwards = awardWinners
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            if (sortedAwards.Values.Count > 0)
            {
                foreach (var singer in sortedAwards)
                {
                    Console.WriteLine($"{singer.Key}: {singer.Value.Count} awards");
                    foreach (var award in singer.Value)
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }

        }
    }
}
