using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem03
{
    class SchoolCamp
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string groupType = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());

            string sport = string.Empty;
            double pricePerNight = 0.0;

            if (groupType == "boys")
            {
                if (season == "Winter")
                {
                    sport = "Judo";
                    pricePerNight = 9.6;
                }
                else if (season == "Spring")
                {
                    sport = "Tennis";
                    pricePerNight = 7.2;
                }
                else if (season == "Summer")
                {
                    sport = "Football";
                    pricePerNight = 15;
                }
            }
            else if (groupType == "girls")
            {
                if (season == "Winter")
                {
                    sport = "Gymnastics";
                    pricePerNight = 9.6;
                }
                else if (season == "Spring")
                {
                    sport = "Athletics";
                    pricePerNight = 7.2;
                }
                else if (season == "Summer")
                {
                    sport = "Volleyball";
                    pricePerNight = 15;
                }
            }
            else if (groupType == "mixed")
            {
                if (season == "Winter")
                {
                    sport = "Ski";
                    pricePerNight = 10;
                }
                else if (season == "Spring")
                {
                    sport = "Cycling";
                    pricePerNight = 9.5;
                }
                else if (season == "Summer")
                {
                    sport = "Swimming";
                    pricePerNight = 20;
                }
            }

            double totalPrice = pricePerNight * nights * students;

            if (students >= 10 && students < 20)
            {
                totalPrice *= 0.95;
            }
            else if (students >= 20 && students < 50)
            {
                totalPrice *= 0.85;
            }
            else if (students >= 50)
            {
                totalPrice *= 0.5;
            }

            Console.WriteLine($"{sport} {totalPrice:f2} lv.");
        }
    }
}
