using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.LongestIncreasingSubsequence
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var maxLength = 0;
            var lastIndex = -1;

            var inputSequence = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var lisLength = new int[inputSequence.Length];
            var previous = new int[inputSequence.Length];

            for (int currIndex = 0; currIndex < inputSequence.Length; currIndex++)
            {
                lisLength[currIndex] = 1;
                previous[currIndex] = -1;

                for (int i = 0; i < currIndex; i++)
                {
                    if (inputSequence[i] < inputSequence[currIndex] && lisLength[i] + 1 > lisLength[currIndex])
                    {
                        lisLength[currIndex]++;
                        previous[currIndex] = i;
                    }
                }

                if (lisLength[currIndex] > maxLength)
                {
                    maxLength = lisLength[currIndex];
                    lastIndex = currIndex;
                }
            }

            var longestSubSequence = new List<int>();

            while (lastIndex != -1)
            {
                longestSubSequence.Add(inputSequence[lastIndex]);
                lastIndex = previous[lastIndex];
            }

            longestSubSequence.Reverse();

            Console.WriteLine(string.Join(" ", longestSubSequence));
        }
    }
}
