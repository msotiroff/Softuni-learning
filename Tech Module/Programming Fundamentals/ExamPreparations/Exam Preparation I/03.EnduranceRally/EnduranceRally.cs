using System;
using System.Linq;

namespace _03.EnduranceRally
{
    class EnduranceRally
    {
        static void Main(string[] args)
        {
            string[] racers = Console.ReadLine()
                .Split(' ')
                .ToArray();
            double[] fuelPerZone = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();
            int[] checkPointIndexes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();


            for (int i = 0; i < racers.Length; i++)
            {
                string currentRacer = racers[i];
                int racerFuel = Convert.ToInt32(currentRacer[0]);
                double racerCurrentFuel = (double)racerFuel;
                for (int j = 0; j < fuelPerZone.Length; j++)
                {
                    if (checkPointIndexes.Contains(j))
                    {
                        racerCurrentFuel += fuelPerZone[j];
                    }
                    else
                    {
                        racerCurrentFuel -= fuelPerZone[j];
                    }
                    if (racerCurrentFuel <= 0)
                    {
                        Console.WriteLine($"{currentRacer} - reached {j}");
                        break;
                    }
                    if (j == fuelPerZone.Length - 1)
                    {
                        Console.WriteLine($"{currentRacer} - fuel left {racerCurrentFuel:f2}");
                    }
                }

            }



            Console.WriteLine();
        }
    }
}
