using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.TruckDriver
{
    class TruckDriver
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmPerMonth = double.Parse(Console.ReadLine());

            double paymentPerKm = 0;

            if (kmPerMonth <= 5000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    paymentPerKm = 0.75;
                }
                else if (season == "Summer")
                {
                    paymentPerKm = 0.9;
                }
                else if (season == "Winter")
                {
                    paymentPerKm = 1.05;
                }
            }
            else if (kmPerMonth <= 10000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    paymentPerKm = 0.95;
                }
                else if (season == "Summer")
                {
                    paymentPerKm = 1.1;
                }
                else if (season == "Winter")
                {
                    paymentPerKm = 1.25;
                }
            }
            else if (kmPerMonth <= 20000)
            {
                paymentPerKm = 1.45;
            }

            double driverPayment = paymentPerKm * kmPerMonth * 4 * 0.9;

            Console.WriteLine($"{driverPayment:f2}");
        }
    }
}
