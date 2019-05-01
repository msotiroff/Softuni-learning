using System;
using System.Linq;

namespace _2.Number_Checker
{
    class NumberChecker
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();
            string resultType = string.Empty;

            if (inputNumber.Contains('.'))
            {
                resultType = "floating-point";
            }
            else
            {
                resultType = "integer";
            }

            Console.WriteLine(resultType);
        }
    }
}
