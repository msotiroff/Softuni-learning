using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.TubesInPool
{
    class TubesInPool
    {
        static void Main(string[] args)
        {
            int poolVolume = int.Parse(Console.ReadLine());
            int pipeOneDebit = int.Parse(Console.ReadLine());
            int pipeTwoDebit = int.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double filled = (pipeOneDebit + pipeTwoDebit) * hours;
            double difference = Math.Abs(filled - poolVolume);
            double poolFilled = (int)(filled / poolVolume * 100);
            double pipeOnePercentage = (int)(pipeOneDebit * hours / filled * 100);
            double pipeTwoPercentage = (int)(pipeTwoDebit * hours / filled * 100);

            if (filled <= poolVolume)
            {
                Console.WriteLine($"The pool is {poolFilled}% full. Pipe 1: {pipeOnePercentage}%. Pipe 2: {pipeTwoPercentage}%.");
            }
            else
            {
                Console.WriteLine($"For {hours} hours the pool overflows with {filled - poolVolume} liters.");
            }

        }
    }
}
