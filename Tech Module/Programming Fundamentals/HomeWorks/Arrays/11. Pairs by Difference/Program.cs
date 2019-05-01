using System;
using System.Linq;

namespace _11.Pairs_by_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int difference = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int diff = Math.Abs(numbers[i] - numbers[j]);
                    if (diff == difference)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);


        }
    }
}
