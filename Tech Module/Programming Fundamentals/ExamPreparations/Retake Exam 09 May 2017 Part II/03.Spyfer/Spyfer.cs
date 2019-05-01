using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Spyfer
{
    class Spyfer
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                int currentNumber = numbers[i];

                if (i == 0 && currentNumber == numbers[i + 1])
                {
                    numbers.RemoveAt(i + 1);
                    i = 0;
                }
                else if (i != 0 && i != numbers.Count - 1 && currentNumber == numbers[i - 1] + numbers[i + 1])
                {
                    numbers.RemoveAt(i + 1);
                    numbers.RemoveAt(i - 1);
                    i = 0;
                }
                else if (i == numbers.Count - 1 && currentNumber == numbers[i - 1])
                {
                    numbers.RemoveAt(i - 1);
                    i = 0;
                }

            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
