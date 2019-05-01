using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstWords = Console.ReadLine().Split(' ').ToArray();
            string[] secondWords = Console.ReadLine().Split(' ').ToArray();

            int shorterArray = Math.Min(firstWords.Length, secondWords.Length);

            int largestCommon = 0;
            int counter = 0;

            for (int i = 0; i < shorterArray; i++)
            {
                if (firstWords[i] == secondWords[i])
                {
                    counter++;
                    if (largestCommon < counter)
                    {
                        largestCommon = counter;
                    }
                }
                else
                {
                    counter = 0;
                }
            }

            counter = 0;
            firstWords = firstWords.Reverse().ToArray();
            secondWords = secondWords.Reverse().ToArray();

            for (int i = 0; i < shorterArray; i++)
            {
                if (firstWords[i] == secondWords[i])
                {
                    counter++;
                    if (largestCommon < counter)
                    {
                        largestCommon = counter;
                    }
                }
                else
                {
                    counter = 0;
                }
            }

            Console.WriteLine(largestCommon);
        }
    }
}
