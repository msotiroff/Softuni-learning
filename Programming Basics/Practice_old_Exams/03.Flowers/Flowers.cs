using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Flowers
{
    class Flowers
    {
        static void Main(string[] args)
        {
            int chrysantemus = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int tulips = int.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();
            string isDayHoliday = Console.ReadLine().ToLower();

            double chrysantemusPrice = 0;
            double rosesPrice = 0;
            double tulipsPrice = 0;

            if (season == "spring" || season == "summer")
            {
                chrysantemusPrice = 2.0;
                rosesPrice = 4.1;
                tulipsPrice = 2.5;
            }
            else if (season == "autumn" || season == "winter")
            {
                chrysantemusPrice = 3.75;
                rosesPrice = 4.5;
                tulipsPrice = 4.15;
            }
            if (isDayHoliday == "y")
            {
                chrysantemusPrice *= 1.15;
                rosesPrice *= 1.15;
                tulipsPrice *= 1.15;
            }

            double bouqet = chrysantemus * chrysantemusPrice + roses * rosesPrice + tulips * tulipsPrice;

            if (season == "spring" && tulips > 7)
            {
                bouqet *= 0.95;
            }
            if (season == "winter" && roses >= 10)
            {
                bouqet *= 0.9;
            }
            if (chrysantemus + roses + tulips > 20)
            {
                bouqet *= 0.8;  
            }

            double totalPrice = bouqet + 2;
            Console.WriteLine("{0:f2}", totalPrice);
        }
    }
}
