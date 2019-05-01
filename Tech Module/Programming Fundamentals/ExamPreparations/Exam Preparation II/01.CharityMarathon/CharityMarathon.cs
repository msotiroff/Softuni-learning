using System;

namespace _01.CharityMarathon
{
    class CharityMarathon
    {
        static void Main(string[] args)
        {
            int marathonInDays = int.Parse(Console.ReadLine());
            long numberOfRunners = long.Parse(Console.ReadLine());
            int avgNumberOfLaps = int.Parse(Console.ReadLine());
            int trackLenght = int.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            double moneyPerKm = double.Parse(Console.ReadLine());

            long maximumRunnersForAllDays = trackCapacity * marathonInDays;

            if (numberOfRunners > maximumRunnersForAllDays)
            {
                numberOfRunners = maximumRunnersForAllDays;
            }

            long totalMeters = numberOfRunners * avgNumberOfLaps * trackLenght;

            double totalKm = (double)totalMeters / 1000;

            double moneyRaised = totalKm * moneyPerKm;

            Console.WriteLine($"Money raised: {moneyRaised:f2}");
        }
    }
}
