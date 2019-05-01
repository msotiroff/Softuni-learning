using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SoftUniAirline
{
    class SoftUniAirline
    {
        static void Main(string[] args)
        {
            int numberOfFlights = int.Parse(Console.ReadLine());

            List<decimal> allProfits = new List<decimal>();

            for (int i = 0; i < numberOfFlights; i++)
            {
                int adultPassangers = int.Parse(Console.ReadLine());
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine());
                int youthPassangers = int.Parse(Console.ReadLine());
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine());
                decimal fuelPricePerHour = decimal.Parse(Console.ReadLine());
                decimal fuelConsumptionPerHour = decimal.Parse(Console.ReadLine());
                int flightDuration = int.Parse(Console.ReadLine());

                decimal currentIncome = adultTicketPrice * adultPassangers + youthTicketPrice * youthPassangers;
                decimal currentExpences = fuelPricePerHour * fuelConsumptionPerHour * flightDuration;

                decimal currentProfit = currentIncome - currentExpences;
                allProfits.Add(currentProfit);

                if (currentIncome >= currentExpences)
                {
                    Console.WriteLine($"You are ahead with {currentProfit:f3}$.");
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {currentProfit:f3}$.");
                }
            }


            Console.WriteLine($"Overall profit -> {allProfits.Sum():f3}$.");

            Console.WriteLine($"Average profit -> {allProfits.Average():f3}$.");
        }
    }
}
