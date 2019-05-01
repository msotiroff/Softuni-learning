using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Transport_Price
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine().ToLower();

            double taxiPrice = 0.79;
            double busPrice = 0.09;
            double trainPrice = 0.06;

            double totalPrice = 0;

            if (n < 20)
            {
                if (dayOrNight == "day")
                {
                    totalPrice = taxiPrice * n + 0.7;
                }
                else if (dayOrNight == "night")
                {
                    taxiPrice = 0.9;
                    totalPrice = taxiPrice * n + 0.7;
                }
            }
            else if (n >= 20 && n < 100)
            {
                totalPrice = busPrice * n;
            }
            else if (n >= 100)
            {
                totalPrice = trainPrice * n;
            }

            Console.WriteLine(totalPrice);
        }
    }
}
