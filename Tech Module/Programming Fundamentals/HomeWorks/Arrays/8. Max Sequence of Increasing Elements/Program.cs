using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Max_Sequence_of_Increasing_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int counter = 1;
            int maxIncreasingElements = 0;
            int lastIndexOfSecquence = 0;

            for (int i = numbers.Length - 1; i > 0; i--)
            {
                if (numbers[i] > numbers[i - 1])
                {
                    counter++;
                    if (maxIncreasingElements <= counter)
                    {
                        maxIncreasingElements = counter;
                        lastIndexOfSecquence = i - 1;
                    }
                }
                else
                {
                    counter = 1;
                }

            }

            if (maxIncreasingElements > 1)
            {
                for (int i = lastIndexOfSecquence; i < lastIndexOfSecquence + maxIncreasingElements; i++)
                {
                    Console.Write(numbers[i] + " ");
                }
                Console.WriteLine();
            }


        }
    }
}
