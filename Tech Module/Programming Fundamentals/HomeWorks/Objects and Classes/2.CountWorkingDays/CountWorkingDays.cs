using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.CountWorkingDays
{
    class CountWorkingDays
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            DateTime[] holidays =
            {
                new DateTime(1500, 1, 1),
                new DateTime(1500, 3, 3),
                new DateTime(1500, 5, 1),
                new DateTime(1500, 5, 6),
                new DateTime(1500, 5, 24),
                new DateTime(1500, 9, 6),
                new DateTime(1500, 9, 22),
                new DateTime(1500, 11, 1),
                new DateTime(1500, 12, 24),
                new DateTime(1500, 12, 25),
                new DateTime(1500, 12, 26)
            };

            int workingDaysCounter = 0;

            for (var i = startDate; i <= endDate;)
            {
                var currentDate = i;

                if (currentDate.DayOfWeek.ToString() == "Saturday" ||
                    currentDate.DayOfWeek.ToString() == "Sunday")
                {
                    i = i.AddDays(1);
                    continue;
                }
                else if (holidays.Select(d => d.DayOfYear).Contains(currentDate.DayOfYear))
                {
                    i = i.AddDays(1);
                    continue;
                }
                else
                {
                    workingDaysCounter++;
                }

                i = i.AddDays(1);
            }


            Console.WriteLine(workingDaysCounter);
        }
    }
}
