using System;
using System.Globalization;

namespace _1.Day_of_Week
{
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            string givenDate = Console.ReadLine();

            DateTime currentDate = DateTime.ParseExact(givenDate, "d-M-yyyy", CultureInfo.InvariantCulture);

            var dayOfWeek = currentDate.DayOfWeek;

            Console.WriteLine(dayOfWeek);
        }
    }
}
