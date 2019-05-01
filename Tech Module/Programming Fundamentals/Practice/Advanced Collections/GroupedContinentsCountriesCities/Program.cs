using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupedContinentsCountriesCities
{
    class Program
    {
        public static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> dataBase =
                new SortedDictionary<string, SortedDictionary<string, SortedSet<string>>>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfInputs; i++)
            {
                AddCurrentInputToDatabase(dataBase);
            }

            PrintSortedDatabase(dataBase);

        }

        public static void PrintSortedDatabase(SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> dataBase)
        {
            foreach (var kvp in dataBase)
            {
                var continent = kvp.Key;
                var country = kvp.Value;
                Console.WriteLine($"{continent}:");

                foreach (var item in country)
                {
                    Console.WriteLine($"  {item.Key} -> {string.Join(", ", item.Value)}");
                }
            }
        }

        public static void AddCurrentInputToDatabase(SortedDictionary<string, SortedDictionary<string, SortedSet<string>>> dataBase)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            string continent = input[0];
            string country = input[1];
            string city = input[2];

            if (!dataBase.ContainsKey(continent))
            {
                dataBase[continent] = new SortedDictionary<string, SortedSet<string>>();
            }
            if (!dataBase[continent].ContainsKey(country))
            {
                dataBase[continent][country] = new SortedSet<string>();
            }

            dataBase[continent][country].Add(city);
        }
    }
}
