using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TearListInHalf
{
    class TearListInHalf
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                .Split(' ')
                                .Select(int.Parse)
                                .ToList();

            List<int> downListOfNumbers = new List<int>();
            List<int> upperListOfNumbers = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                downListOfNumbers.Add(numbers[i]);
            }
            for (int i = numbers.Count / 2; i < numbers.Count; i++)
            {
                upperListOfNumbers.Add(numbers[i]);
            }

            List<int> upperDigits = new List<int>();

            for (int i = 0; i < upperListOfNumbers.Count; i++)
            {
                int secondDigit = upperListOfNumbers[i] % 10;
                upperListOfNumbers[i] /= 10;
                int firstDigit = upperListOfNumbers[i] % 10;
                upperDigits.Add(firstDigit);
                upperDigits.Add(secondDigit);
            }
            int indexCounter = 0;
            for (int i = 0; i < upperDigits.Count; i++)
            {
                    downListOfNumbers.Insert(i + indexCounter, upperDigits[i]);

                if (i % 2 == 0)
                {
                    indexCounter++;
                }
             
            }

            Console.WriteLine(string.Join(" ", downListOfNumbers));
        }
    }
}
