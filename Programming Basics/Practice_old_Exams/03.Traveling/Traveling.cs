using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Traveling
{
    class Traveling
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine().ToLower();

            double spent = 0.0;
            string destination = string.Empty;
            string accommodation = string.Empty;

            if (budget <= 100)
            {
                destination = "Bulgaria";
                if (season == "summer")
                {
                    accommodation = "Camp";
                    spent = budget * 0.3;
                }
                else if (season == "winter")
                {
                    accommodation = "Hotel";
                    spent = budget * 0.7;
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
                if (season == "summer")
                {
                    accommodation = "Camp";
                    spent = budget * 0.4;
                }
                else if (season == "winter")
                {
                    accommodation = "Hotel";
                    spent = budget * 0.8;
                }
            }
            else
            {
                destination = "Europe";
                accommodation = "Hotel";
                spent = budget * 0.9;
            }

            Console.WriteLine("Somewhere in {0}", destination);
            Console.WriteLine($"{accommodation} - {spent:f2}");
        }
    }
}
