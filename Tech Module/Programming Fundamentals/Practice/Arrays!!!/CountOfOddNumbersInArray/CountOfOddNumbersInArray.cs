using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfOddNumbersInArray
{
    class CountOfOddNumbersInArray
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int oddNumbersCount = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 != 0)
                {
                    oddNumbersCount++;
                }
            }
            Console.WriteLine(oddNumbersCount);
        }
    }
}

