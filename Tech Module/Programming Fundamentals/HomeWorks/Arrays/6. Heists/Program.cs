using System;
using System.Linq;

namespace _6.Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] prices = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            long totalEarning = 0;
            long totalExpences = 0;
            int jelewsPrice = prices[0];
            int goldPrice = prices[1];

            string inputLine = Console.ReadLine();

            while (inputLine != "Jail Time")
            {
                string[] inputParameters = inputLine.Split(' ').ToArray();
                string currentLoot = inputParameters[0];
                long currentExpences = long.Parse(inputParameters[1]);

                for (int i = 0; i < currentLoot.Length; i++)
                {
                    if (currentLoot[i] == '%')
                    {
                        totalEarning += jelewsPrice;
                    }
                    else if (currentLoot[i] == '$')
                    {
                        totalEarning += goldPrice;
                    }
                }
                totalExpences += currentExpences;


                inputLine = Console.ReadLine();
            }

            long difference = Math.Abs(totalEarning - totalExpences);

            if (totalEarning >= totalExpences)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {difference}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {difference}.");
            }
        }
    }
}
