using System;

namespace _01.CharityMarathon
{
    class CharityMarathon
    {
        static void Main(string[] args)
        {
            int marathonDays = int.Parse(Console.ReadLine());
            int numberOfRunners = int.Parse(Console.ReadLine());
            int avgLaps = int.Parse(Console.ReadLine());
            int trackLenght = int.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            decimal moneyPerKm = decimal.Parse(Console.ReadLine());

            int maximumRunners = trackCapacity * marathonDays;
            if (numberOfRunners > maximumRunners)
            {
                numberOfRunners = maximumRunners;
            }
            long totalMeters = (long)numberOfRunners * avgLaps * trackLenght;
            decimal totalKm = (decimal)totalMeters / 1000;

            decimal moneyRaised = totalKm * moneyPerKm;

            Console.WriteLine($"Money raised: {moneyRaised:f2}");
        }
    }
}
