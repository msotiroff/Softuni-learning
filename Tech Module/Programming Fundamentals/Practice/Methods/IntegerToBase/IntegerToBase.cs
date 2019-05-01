using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerToBases
{
    class IntegerToBases
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            int toBase = int.Parse(Console.ReadLine());

            string converted = IntegerToBase(number, toBase);
            Console.WriteLine(converted);
        }

        static string IntegerToBase(long number, int toBase)
        {
            string result = string.Empty;

            while (number > 0)
            {
                long reminder = number % toBase;
                result = reminder + result;
                number /= toBase;
            }
            return result;
        }
    }
}
