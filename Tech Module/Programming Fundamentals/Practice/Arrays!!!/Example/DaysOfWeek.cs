using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysOfWeek
{
    class DaysOfWeek
    {
        static void Main(string[] args)
        {
            string [] daysOfWeek  = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            try
            {
                int day = int.Parse(Console.ReadLine());
                Console.WriteLine(daysOfWeek[day - 1]);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid day!");
            }


        }
    }
}
