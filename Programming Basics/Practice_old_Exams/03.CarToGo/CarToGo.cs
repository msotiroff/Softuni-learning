using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CarToGo
{
    class CarToGo
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string klass = "Luxury class";
            string carType = "Jeep";
            double spentMoney = 0;

            if (budget <= 100)
            {
                klass = "Economy class";
                if (season == "Summer")
                {
                    carType = "Cabrio";
                    spentMoney = budget * 0.35;
                }
                else if(season == "Winter")
                {
                    spentMoney = budget * 0.65;
                }
            }
            else if (budget <= 500)
            {
                klass = "Compact class";
                if (season == "Summer")
                {
                    carType = "Cabrio";
                    spentMoney = budget * 0.45;
                }
                else if (season == "Winter")
                {
                    spentMoney = budget * 0.8;
                }
            }
            else
            {
                spentMoney = budget * 0.9;
            }

            Console.WriteLine($"{klass}");
            Console.WriteLine($"{carType} - {spentMoney:f2}");
        }
    }
}
