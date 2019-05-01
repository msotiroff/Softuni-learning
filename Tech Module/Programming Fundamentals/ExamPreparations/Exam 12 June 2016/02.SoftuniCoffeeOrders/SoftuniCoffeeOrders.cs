using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftuniCoffeeOrders
{
    class SoftuniCoffeeOrders
    {
        static void Main(string[] args)
        {
            int countOfOrders = int.Parse(Console.ReadLine());

            decimal totalBill = 0;


            for (int i = 0; i < countOfOrders; i++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime dateOfOrder = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                int capsulesCount = int.Parse(Console.ReadLine());

                int daysInCurrentMonth = DateTime.DaysInMonth(dateOfOrder.Year, dateOfOrder.Month);

                decimal currentOrderCosts = pricePerCapsule * (decimal)daysInCurrentMonth * (decimal)capsulesCount;

                Console.WriteLine($"The price for the coffee is: ${currentOrderCosts:f2}");

                totalBill += currentOrderCosts;
            }


            Console.WriteLine($"Total: ${totalBill:f2}");


        }
    }
}
