using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace _2.SortTimes
{
    class SortTimes
    {
        static void Main(string[] args)
        {
            List<string> times = Console.ReadLine().Split(' ').ToList();
            
            List<DateTime> realTimes = new List<DateTime>();

            for (int i = 0; i < times.Count; i++)
            {
                string currentTimeAsString = times[i];
                DateTime currentTime = DateTime.ParseExact(currentTimeAsString, "HH:mm", CultureInfo.InvariantCulture);
                realTimes.Add(currentTime);
            }

            realTimes = realTimes.OrderBy(time => time.TimeOfDay.ToString()).ToList();

            List<string> sortedTimes = new List<string>();

            for (int i = 0; i < realTimes.Count; i++)
            {
                sortedTimes.Add($"{realTimes[i].Hour:00}:{realTimes[i].Minute:00}");
            }

            Console.WriteLine(string.Join(", ", sortedTimes));

        }
    }
}
