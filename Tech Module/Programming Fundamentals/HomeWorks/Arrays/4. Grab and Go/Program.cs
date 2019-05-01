using System;
using System.Linq;

namespace _4.Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] inputNumbers = Console.ReadLine()
                .Split(' ')
                .Select(long.Parse)
                .ToArray();
            int n = int.Parse(Console.ReadLine());

            long sum = 0;

            bool foundN = false;

            for (int i = inputNumbers.Length - 1; i >= 0; i--)
            {
                if (n == inputNumbers[i])
                {
                    foundN = true;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        sum += inputNumbers[j];
                    }
                    break;
                }
            }

            if (foundN)
            {
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No occurrences were found!");
            }
        }
    }
}
