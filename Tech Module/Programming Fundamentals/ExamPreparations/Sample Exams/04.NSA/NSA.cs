using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.NSA
{
    class NSA
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> allSpies
                = new Dictionary<string, Dictionary<string, int>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "quit")
            {
                string[] inputParameters = inputLine
                    .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string currentCountry = inputParameters[0];
                string currentSpy = inputParameters[1];
                int currentDaysInService = int.Parse(inputParameters[2]);

                if (! allSpies.ContainsKey(currentCountry))
                {
                    allSpies[currentCountry] = new Dictionary<string, int>();
                }
                if (! allSpies[currentCountry].ContainsKey(currentSpy))
                {
                    allSpies[currentCountry][currentSpy] = 0;
                }
                allSpies[currentCountry][currentSpy] = currentDaysInService;


                inputLine = Console.ReadLine();
            }


            foreach (var county in allSpies.OrderByDescending(c => c.Value.Count))
            {
                Console.WriteLine($"Country: {county.Key}");

                foreach (var spy in county.Value.OrderByDescending(s => s.Value))
                {
                    Console.WriteLine($"**{spy.Key} : {spy.Value}");
                }
            }


        }
    }
}
