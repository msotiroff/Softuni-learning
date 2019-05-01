using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfGivenElementInArray
{
    class CountOfGivenElementInArray
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int givenElement = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == givenElement)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
