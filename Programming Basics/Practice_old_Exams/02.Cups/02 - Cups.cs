using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Cups
{
    class Cups
    {
        static void Main(string[] args)
        {
            int cupsToBeMade = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int workingDays = int.Parse(Console.ReadLine());

            int humanHours = workers * workingDays * 8;
            int madeCups = humanHours / 5;

            double difference = Math.Abs(madeCups - cupsToBeMade);

            
            if (madeCups >= cupsToBeMade)
            {
                Console.WriteLine("{0:f2} extra money", difference * 4.2);
            }
            else
            {
                Console.WriteLine("Losses: {0:f2}", difference * 4.2);
            }

        }
    }
}