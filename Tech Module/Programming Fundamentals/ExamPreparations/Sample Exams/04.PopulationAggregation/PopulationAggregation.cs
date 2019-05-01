using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.PopulationAggregation
{
    class PopulationAggregation
    {
        static void Main(string[] args)
        {
            //               Country             City   [0]-Population, [1]-Count of cities
            SortedDictionary<string, Dictionary<string, List<long>>> allCountries =
                new SortedDictionary<string, Dictionary<string, List<long>>>();

            Dictionary<string, long> onlyCities = new Dictionary<string, long>();

            string inputLine = Console.ReadLine();

            while (inputLine != "stop")
            {
                string[] inputParameters = inputLine.Split('\\').ToArray();

                string currentCountry = string.Empty;
                string currentCity = string.Empty;
                long currCityPopulation = long.Parse(inputParameters[2]);

                if (char.IsUpper(inputParameters[0][0]))
                {
                    currentCountry = inputParameters[0];
                    currentCity = inputParameters[1];
                }
                else
                {
                    currentCountry = inputParameters[1];
                    currentCity = inputParameters[0];
                }

                currentCountry = ClearProhibitedSymbols(currentCountry);
                currentCity = ClearProhibitedSymbols(currentCity);

                if (!allCountries.ContainsKey(currentCountry))
                {
                    allCountries[currentCountry] = new Dictionary<string, List<long>>();
                }
                if (!allCountries[currentCountry].ContainsKey(currentCity))
                {
                    allCountries[currentCountry][currentCity] = new List<long>();
                    allCountries[currentCountry][currentCity].Add(0);
                    allCountries[currentCountry][currentCity].Add(0);
                }

                allCountries[currentCountry][currentCity][0] = currCityPopulation;
                allCountries[currentCountry][currentCity][1]++;
                onlyCities[currentCity] = currCityPopulation;

                inputLine = Console.ReadLine();
            }

            PrintResult(allCountries, onlyCities);

        }

        public static void PrintResult(
            SortedDictionary<string, Dictionary<string, List<long>>> allCountries, 
            Dictionary<string, long> onlyCities
                                      )
        {
            foreach (var country in allCountries)
            {
                string currentCountry = country.Key;
                long count = allCountries[currentCountry].Values.Sum(x => x[1]);
                Console.WriteLine($"{currentCountry} -> {count}");
            }

            int topThreeCounter = 0;


            foreach (var city in onlyCities.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{city.Key} -> {city.Value}");
                topThreeCounter++;
                if (topThreeCounter == 3)
                {
                    break;
                }
            }
        }

        public static string ClearProhibitedSymbols(string name)
        {
            string clearedName = string.Empty;

            var prohibitedSymbols = "@#$&0123456789".ToCharArray();

            for (int i = 0; i < name.Length; i++)
            {
                if (! prohibitedSymbols.Contains(name[i]))
                {
                    clearedName += name[i];
                }
            }

            return clearedName;
        }
    }
}
