using System;
using System.Globalization;

namespace _01.SoftuniCoffeeOrders
{
    class SoftuniCoffeeOrders
    {
        static void Main(string[] args)
        {
            int countOfOrders = int.Parse(Console.ReadLine());

            decimal totalPrice = 0;

            for (int i = 0; i < countOfOrders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                int capsulesCount = int.Parse(Console.ReadLine());
                int daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

                decimal currentPrice = pricePerCapsule * daysInMonth * capsulesCount;
                totalPrice += currentPrice;

                Console.WriteLine($"The price for the coffee is: ${currentPrice:f2}");
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
