using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HornetAssault
{
    class HornetAssault
    {
        static void Main(string[] args)
        {
            List<long> beehives = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToList();

            List<long> hornets = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToList();

            for (int i = 0; i < beehives.Count; i++)
            {
                long powerOfHornets = hornets.Sum();

                long currentBeehive = beehives[i];

                if (powerOfHornets > currentBeehive)
                {
                    beehives[i] = 0;
                }
                else
                {
                    beehives[i] -= powerOfHornets;

                    hornets.RemoveAt(0);
                    if (hornets.Count == 0)
                    {
                        break;
                    }
                }
            }

            if (beehives.Sum() > 0)
            {
                Console.WriteLine(string.Join(" ", beehives.Where(b => b > 0)));
            }
            else if (hornets.Sum() > 0)
            {
                Console.WriteLine(string.Join(" ", hornets.Where(h => h > 0)));
            }
        }
    }
}
