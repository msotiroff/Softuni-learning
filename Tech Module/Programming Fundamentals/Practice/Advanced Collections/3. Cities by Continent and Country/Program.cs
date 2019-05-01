using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> globalDataBase = 
                new Dictionary<string, Dictionary<string, List<string>>>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] currentInput = Console.ReadLine().Split(' ').ToArray();

                string currentContinent = currentInput[0];
                string currentCountry = currentInput[1];
                string currentTown = currentInput[2];

                if (! globalDataBase.ContainsKey(currentContinent))
                {
                    globalDataBase[currentContinent] = new Dictionary<string, List<string>>();
                }
                if (! globalDataBase[currentContinent].ContainsKey(currentCountry))
                {
                    globalDataBase[currentContinent][currentCountry] = new List<string>();
                }
                globalDataBase[currentContinent][currentCountry].Add(currentTown);
            }

            foreach (var continent in globalDataBase)
            {
                string continentName = continent.Key;
                var countries = continent.Value;
                Console.WriteLine($"{continentName}:");
                foreach (var kvp in countries)
                {
                    Console.WriteLine($"  {kvp.Key} -> {string.Join(", ", kvp.Value)}");
                }
                
            }
        }
    }
}
