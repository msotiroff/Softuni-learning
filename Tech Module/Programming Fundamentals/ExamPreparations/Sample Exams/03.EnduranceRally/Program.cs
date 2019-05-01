using System;
using System.Linq;

namespace _03.EnduranceRally
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] racers = Console.ReadLine().Split(' ');
            double[] zones = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToArray();
            int[] checkPoints = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();


            for (int i = 0; i < racers.Length; i++)
            {
                string currentRacer = racers[i];
                int currentRacerStartFuel = Convert.ToInt32(currentRacer[0]);
                double currentRacerFuel = 1.0 * currentRacerStartFuel;

                for (int j = 0; j < zones.Length; j++)
                {
                    if (checkPoints.Contains(j))
                    {
                        currentRacerFuel += zones[j];
                    }
                    else
                    {
                        currentRacerFuel -= zones[j];
                    }
                    if (currentRacerFuel <= 0)
                    {
                        Console.WriteLine($"{currentRacer} - reached {j}");
                        break;
                    }
                    if (j == zones.Length - 1)
                    {
                        Console.WriteLine($"{currentRacer} - fuel left {currentRacerFuel:f2}");
                    }
                }
            }
        }
    }
}
