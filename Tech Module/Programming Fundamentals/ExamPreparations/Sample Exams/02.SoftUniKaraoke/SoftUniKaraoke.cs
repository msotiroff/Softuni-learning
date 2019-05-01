using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SoftUniKaraoke
{
    class SoftUniKaraoke
    {
        static void Main(string[] args)
        {
            //               Singer         Awards
            SortedDictionary<string, SortedSet<string>> allAwards =
                new SortedDictionary<string, SortedSet<string>>();

            string[] availableSingers = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            string[] availableSongs = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            string command = Console.ReadLine();

            while (command != "dawn")
            {
                string[] commandParameters = command
                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                string currentSinger = commandParameters[0];
                string currentSong = commandParameters[1];
                string currentAward = commandParameters[2];

                if (availableSingers.Contains(currentSinger) && availableSongs.Contains(currentSong))
                {
                    if (! allAwards.ContainsKey(currentSinger))
                    {
                        allAwards[currentSinger] = new SortedSet<string>();
                    }
                    allAwards[currentSinger].Add(currentAward);
                }
                

                command = Console.ReadLine();
            }



            if (allAwards.Count > 0)
            {
                foreach (var singer in allAwards.Where(s => s.Value.Count > 0).OrderByDescending(s => s.Value.Count))
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
