namespace P04.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var allCountries = new Dictionary<string, Dictionary<string, long>>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "report")
            {
                var inputArgs = inputLine
                    .Split('|')
                    .Select(x => x.Trim())
                    .ToArray();

                var country = inputArgs[1];
                var town = inputArgs[0];
                var population = long.Parse(inputArgs[2]);

                if (!allCountries.ContainsKey(country))
                {
                    allCountries[country] = new Dictionary<string, long>();
                }
                if (!allCountries[country].ContainsKey(town))
                {
                    allCountries[country][town] = 0;
                }

                allCountries[country][town] = population;
            }

            foreach (var country in allCountries.OrderByDescending(c => c.Value.Sum(v => v.Value)))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value.Sum(v => v.Value)})");

                foreach (var town in country.Value.OrderByDescending(t => t.Value))
                {
                    Console.WriteLine($"=>{town.Key}: {town.Value}");
                }
            }
        }
    }
}
