using System;

namespace _01.SplinterTrip
{
    class SplinterTrip
    {
        static void Main(string[] args)
        {
            double tripDistance = double.Parse(Console.ReadLine());
            double fuelTankCapacity = double.Parse(Console.ReadLine());
            double milesInHeavyWind = double.Parse(Console.ReadLine());

            double nonHeavyWindConsumption = 25.0 * (tripDistance - milesInHeavyWind);
            double heavyWindConsumption = 1.5 * 25 * milesInHeavyWind;

            double totalConsumption = nonHeavyWindConsumption + heavyWindConsumption;
            double consumptionPlusTolerance = 1.05 * totalConsumption;

            double difference = Math.Abs(fuelTankCapacity - consumptionPlusTolerance);

            Console.WriteLine($"Fuel needed: {consumptionPlusTolerance:f2}L");

            if (consumptionPlusTolerance <= fuelTankCapacity)
            {
                Console.WriteLine($"Enough with {difference:f2}L to spare!");
            }
            else
            {
                Console.WriteLine($"We need {difference:f2}L more fuel.");
            }
        }
    }
}
