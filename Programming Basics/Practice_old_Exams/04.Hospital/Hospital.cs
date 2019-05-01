using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());

            int doctors = 7;
            int treated = 0;
            int untreated = 0;

            for (int i = 1; i <= days; i++)
            {
                int currentDayPatients = int.Parse(Console.ReadLine());
                if (i % 3 == 0)
                {
                    if (treated < untreated)
                    {
                        doctors++;
                    }
                }
                if (currentDayPatients <= doctors)
                {
                    treated += currentDayPatients;
                }
                else
                {
                    treated += doctors;
                    untreated += currentDayPatients - doctors;
                }
            }

            Console.WriteLine($"Treated patients: {treated}.");
            Console.WriteLine($"Untreated patients: {untreated}.");
        }
    }
}
