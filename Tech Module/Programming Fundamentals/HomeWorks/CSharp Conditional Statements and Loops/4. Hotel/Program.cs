using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Hotel
{
    class Hotel
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double doublePrice = 0;
            double suitePrice = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = 50 * nightsCount;
                doublePrice = 65 * nightsCount;
                suitePrice = 75 * nightsCount;
                if (nightsCount > 7)
                {
                    studioPrice *= 0.95;
                    if (month == "October")
                    {
                        studioPrice = (studioPrice / nightsCount) * (nightsCount - 1);
                    }
                }
            }
            else if (month == "June" || month == "September")
            {
                studioPrice = 60 * nightsCount;
                doublePrice = 72 * nightsCount;
                suitePrice = 82 * nightsCount;
                if (nightsCount > 14)
                {
                    doublePrice *= 0.9;
                }
                if (nightsCount > 7 && month == "September")
                {
                        studioPrice = (studioPrice / nightsCount) * (nightsCount - 1);
                }
            }
            else if (month == "July" || month == "August" || month == "December")
            {
                studioPrice = 68 * nightsCount;
                doublePrice = 77 * nightsCount;
                suitePrice = 89 * nightsCount;
                if (nightsCount > 14)
                {
                    suitePrice *= 0.85;
                }
            }


            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
            Console.WriteLine($"Double: {doublePrice:f2} lv.");
            Console.WriteLine($"Suite: {suitePrice:f2} lv.");
        }
    }
}
