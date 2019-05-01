using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] sum = new int[numbers.Length];

            int timesToRotate = int.Parse(Console.ReadLine());

            for (int i = 0; i < timesToRotate; i++)
            {
                int lastElement = numbers.Last();
                for (int j = numbers.Length - 1; j > 0; j--)
                {
                    numbers[j] = numbers[j - 1];
                }
                numbers[0] = lastElement;

                for (int k = 0; k < sum.Length; k++)
                {
                    sum[k] += numbers[k];
                }
            }

            Console.WriteLine(string.Join(" ", sum));
        }
    }
}
