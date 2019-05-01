namespace P10.PopulationCounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PopulationCounter
    {
        public static void Main(string[] args)
        {
            var populationStatistic = new Dictionary<string, Dictionary<string, long>>();

            // Input format: city|country|population
            string inputLine;
            while ((inputLine = Console.ReadLine()) != "report")
            {
                var inputParams = inputLine.Split('|');

                var city = inputParams[0];
                var country = inputParams[1];
                var population = long.Parse(inputParams[2]);

                if (!populationStatistic.ContainsKey(country))
                {
                    populationStatistic[country] = new Dictionary<string, long>();
                }

                if (!populationStatistic[country].ContainsKey(city))
                {
                    populationStatistic[country][city] = population;
                }
            }

            // Print output:
            foreach (var country in populationStatistic.OrderByDescending(c => c.Value.Sum(city => city.Value)))
            {
                string countryName = country.Key;
                long totalPopulation = country.Value.Sum(v => v.Value);
                Console.WriteLine($"{countryName} (total population: {totalPopulation})");

                foreach (var city in country.Value.OrderByDescending(city => city.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }
    }
}
