using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlants
{
    class PowerPlants
    {
        static void Main(string[] args)
        {
            int[] plantsPower = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToArray();

            int daysPerSeason = plantsPower.Length;

            int days = 0;
            int seasons = 0;
            
            for (int i = 0; i < daysPerSeason; i++)
            {
                for (int j = 0; j < plantsPower.Length; j++)
                {
                    if (plantsPower[j] != 0)
                    {
                        if (i != j)
                        {
                            plantsPower[j] -= 1;
                        }
                    }
                }
                days++;
                int powerInArray = 0;
                foreach (var item in plantsPower)
                {
                    powerInArray += item;
                }
                if (powerInArray == 0)
                {
                    break;
                }
                if (i == daysPerSeason - 1 && powerInArray != 0)
                {
                    for (int k = 0; k < plantsPower.Length; k++)
                    {
                        if (plantsPower[k] > 0)
                        {
                            plantsPower[k]++;
                        }
                    }
                    i = -1;
                    seasons++;
                }
            }

            if (seasons == 1)
            {
                Console.WriteLine($"survived {days} days ({seasons} season)");
            }
            else
            {
                Console.WriteLine($"survived {days} days ({seasons} seasons)");
            }
        }
    }
}

