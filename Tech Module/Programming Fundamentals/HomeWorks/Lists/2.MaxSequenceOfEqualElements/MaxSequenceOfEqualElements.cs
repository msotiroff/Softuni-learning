using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.MaxSequenceOfEqualElements
{
    class MaxSequenceOfEqualElements
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> currentSequentOfEquals = new List<int>();
            List<int> maxSequenceOfEquals = new List<int>();
            currentSequentOfEquals.Add(numbers[0]);

            for (int i = 1; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];
                int neededNumber = currentSequentOfEquals[0];
                if (currentNumber == neededNumber)
                {
                    currentSequentOfEquals.Add(currentNumber);
                }
                else
                {
                    if (currentSequentOfEquals.Count > maxSequenceOfEquals.Count)
                    {
                        maxSequenceOfEquals = currentSequentOfEquals.ToList();
                    }
                    currentSequentOfEquals.Clear();
                    currentSequentOfEquals.Add(currentNumber);
                }
                if (currentSequentOfEquals.Count > maxSequenceOfEquals.Count)
                {
                    maxSequenceOfEquals = currentSequentOfEquals.ToList();
                }
            }

            Console.WriteLine(string.Join(" ", maxSequenceOfEquals));
        }
    }
}
