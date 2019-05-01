using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthDigit
{
    class NthDigit
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            int index = int.Parse(Console.ReadLine());

            int nthDigit = FindNthDigit(number, index);
            Console.WriteLine(nthDigit);
        }

        static int FindNthDigit(long number, int index)
        {
            long result = 0;
            while (index > 0)
            {
                result = number % 10;
                index--;
                number /= 10;
            }
            return (int)result;
        }
    }
}
