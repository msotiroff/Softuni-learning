using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Population_Counter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> population = 
                new Dictionary<string, Dictionary<string, long>>();

            string inputLine = Console.ReadLine();

            while (inputLine != "report")
            {
                string[] inputParameters = inputLine.Split('|').ToArray();
                string currentCountry = inputParameters[1];
                string currentCity = inputParameters[0];
                long currentPeople = long.Parse(inputParameters[2]);

                if (! population.ContainsKey(currentCountry))
                {
                    population[currentCountry] = new Dictionary<string, long>();
                }
                population[currentCountry][currentCity] = currentPeople;

                inputLine = Console.ReadLine();
            }
            

            foreach (var item in population.OrderByDescending(x => x.Value.Sum(y => y.Value)))
            {
                long currentCountryPopulation = item.Value.Values.Sum();
                Console.WriteLine($"{item.Key} (total population: {currentCountryPopulation})");

                foreach (var city in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }

        }
    }
}
