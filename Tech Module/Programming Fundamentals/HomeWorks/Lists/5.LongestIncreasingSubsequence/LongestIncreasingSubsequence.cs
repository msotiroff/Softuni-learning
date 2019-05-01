using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.LongestIncreasingSubsequence
{
    class LongestIncreasingSubsequence
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int[] lenght = new int[numbers.Count];
            int[] previous = new int[numbers.Count];

            int maxLenght = 0;
            int lastIndex = -1;

            for (int i = 0; i < numbers.Count; i++)
            {
                lenght[i] = 1;
                previous[i] = -1;

                for (int j = 0; j < i; j++)
                {
                    if (numbers[i] > numbers[j] && lenght[j] + 1 > lenght[i])
                    {
                        lenght[i] = lenght[j] + 1;
                        previous[i] = j;
                    }
                }

                if (lenght[i] > maxLenght)
                {
                    maxLenght = lenght[i];
                    lastIndex = i;
                }
            }


            List<int> longestSequenceOfIncreasing = new List<int>();

            while (lastIndex > -1)
            {
                longestSequenceOfIncreasing.Add(numbers[lastIndex]);
                lastIndex = previous[lastIndex];
            }

            longestSequenceOfIncreasing.Reverse();

            Console.WriteLine(string.Join(" ", longestSequenceOfIncreasing));

        }
    }
}
