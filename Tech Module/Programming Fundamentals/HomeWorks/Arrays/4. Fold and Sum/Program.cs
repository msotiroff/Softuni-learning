using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int k = numbers.Length / 4;

            int[] upperLeftRow = numbers.Take(k).Reverse().ToArray();
            int[] upperRightRow = numbers.Reverse().Take(k).ToArray();

            int[] upperRow = upperLeftRow.Concat(upperRightRow).ToArray();

            int[] downRow = numbers.Skip(k).Take(2 * k).ToArray();

            int[] sum = new int[2 * k];

            for (int i = 0; i < sum.Length; i++)
            {
                sum[i] = downRow[i] + upperRow[i];
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
