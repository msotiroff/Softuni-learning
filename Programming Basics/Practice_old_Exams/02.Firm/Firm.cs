using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Firm
{
    class Firm
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int daysForWorking = int.Parse(Console.ReadLine());
            int overtimeWorkers = int.Parse(Console.ReadLine());

            double hoursForWorking = daysForWorking * 0.9 * 8;
            double overtimeHours = overtimeWorkers * daysForWorking * 2;

            double allHours = Math.Floor(hoursForWorking + overtimeHours);
            double difference = Math.Abs(neededHours - allHours);

            if (allHours >= neededHours)
            {
                Console.WriteLine($"Yes!{difference} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{difference} hours needed.");
            }
        }
    }
}
