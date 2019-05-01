using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingLightSpeed
{
    class TravelingLightSpeed
    {
        static void Main(string[] args)
        {
            decimal lightYearsInKm = decimal.Parse(Console.ReadLine()) * 9450000000000;
            decimal timeInSeconds = lightYearsInKm / 300000;

            decimal weeks = timeInSeconds / 60 / 60 / 24 / 7;
            decimal days = timeInSeconds / 60 / 60 / 24 % 7;
            decimal hours = timeInSeconds / 60 / 60 % 24;
            decimal minutes = timeInSeconds / 60 % 60;
            decimal seconds = timeInSeconds % 60;

            Console.WriteLine("{0} weeks", Math.Floor(weeks));
            Console.WriteLine("{0} days", Math.Floor(days));
            Console.WriteLine("{0} hours", Math.Floor(hours));
            Console.WriteLine("{0} minutes", Math.Floor(minutes));
            Console.WriteLine("{0} seconds", Math.Floor(seconds));
        }
    }
}