using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.SumReversedNumbers
{
    class SumReversedNumbers
    {
        static void Main(string[] args)
        {
            List<string> numbersAsString = Console.ReadLine()
                .Split(' ')
                .ToList();

            List<string> reversedNumbers = new List<string>();

            for (int i = 0; i < numbersAsString.Count; i++)
            {
                string reversedNumber = string.Empty;
                for (int j = numbersAsString[i].Length - 1; j >= 0; j--)
                {
                    reversedNumber += numbersAsString[i][j];
                }
                reversedNumbers.Add(reversedNumber);
            }

            List<double> numbersToSum = reversedNumbers.Select(double.Parse).ToList();

            Console.WriteLine(numbersToSum.Sum().ToString());
        }
    }
}
