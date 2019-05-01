using System;
using System.Globalization;

namespace _01.SoftuniCoffeeOrders
{
    class SoftuniCoffeeOrders
    {
        static void Main(string[] args)
        {
            int countOfOrders = int.Parse(Console.ReadLine());

            decimal allCosts = 0;

            for (int i = 0; i < countOfOrders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                long capsulesCount = long.Parse(Console.ReadLine());

                int daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

                decimal currentOrderCosts = (decimal)daysInMonth * (decimal)capsulesCount * pricePerCapsule;

                Console.WriteLine($"The price for the coffee is: ${currentOrderCosts:f2}");

                allCosts += currentOrderCosts;
            }

            Console.WriteLine($"Total: ${allCosts:f2}");

        }
    }
}
