using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.WorkHours
{
    class WorkHours
    {
        static void Main(string[] args)
        {
            int neededHours = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int workDays = int.Parse(Console.ReadLine());

            int humanHours = workers * workDays * 8;
            int difference = Math.Abs(neededHours - humanHours);

            if (neededHours <= humanHours)
            {
                Console.WriteLine($"{difference} hours left");
            }
            else
            {
                Console.WriteLine($"{difference} overtime");
                Console.WriteLine($"Penalties: {difference * workDays}");
            }

        }
    }
}
