using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Fold_and_Sum
{
    class Fold_and_Sum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int k = numbers.Length / 4;

            int[] downRow = numbers.Skip(k)
                .Take(2 * k)
                .ToArray();

            int[] leftUpperRow = numbers
                .Take(k)
                .Reverse()
                .ToArray();

            int[] rightUpperRow = numbers
                .Reverse()
                .Take(k)
                .ToArray();

            int[] topRow = leftUpperRow
                .Concat(rightUpperRow)
                .ToArray();
            
            int[] result = new int[downRow.Length];

            for (int i = 0; i < downRow.Length; i++)
            {
                result[i] = downRow[i] + topRow[i];
            }

            Console.WriteLine(string.Join(" ", result));

        }
    }
}
