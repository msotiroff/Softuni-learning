using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                int leftElement = 0;
                int currentElement = numbers[i];
                int rightElement = 0;

                if (i != 0)
                {
                    leftElement = numbers[i - 1];
                }
                if (i != numbers.Count - 1)
                {
                    rightElement = numbers[i + 1];
                }

                int currentSumOfNeighbors = leftElement + rightElement;

                if (currentSumOfNeighbors == currentElement)
                {
                    if (i != 0 && i != numbers.Count - 1)
                    {
                        numbers.RemoveAt(i + 1);
                        numbers.RemoveAt(i - 1);
                        i = 0;
                    }
                    else if (i == 0 && numbers.Count > 1)
                    {
                        numbers.RemoveAt(i + 1);
                        i = 0;
                    }
                    else if (i == numbers.Count - 1 && numbers.Count > 1)
                    {
                        numbers.RemoveAt(i - 1);
                        i = 0;
                    }
                }

            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
