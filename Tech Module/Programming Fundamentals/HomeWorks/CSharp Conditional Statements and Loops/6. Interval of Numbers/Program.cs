using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Interval_of_Numbers
{
    class IntervalOfNumbers
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            if (startNumber < endNumber)
            {
                for (int i = startNumber; i <= endNumber; i++)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                for (int i = endNumber; i <= startNumber; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
