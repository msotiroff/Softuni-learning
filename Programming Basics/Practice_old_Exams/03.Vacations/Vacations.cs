using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Vacations
{
    class Vacations
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            string location = "Alaska";
            if (season == "winter")
            {
                location = "Morocco";
            }
            string accomodation = "Camp";
            double price = 0;

            if (budget <= 1000)
            {
                if (season == "summer")
                {
                    price = budget * 0.65;
                }
                else if (season == "winter")
                {
                    price = budget * 0.45;
                }
            }
            else if (budget <= 3000)
            {
                accomodation = "Hut";
                if (season == "summer")
                {
                    price = 0.8 * budget;
                }
                else if (season == "winter")
                {
                    price = budget * 0.6;
                }
            }
            else
            {
                accomodation = "Hotel";
                price = budget * 0.9;
            }

            Console.WriteLine($"{location} - {accomodation} - {price:f2}");
        }
    }
}
