using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSumAfterExtraction
{
    class EqualSumAfterExtraction
    {
        static void Main(string[] args)
        {
            List<int> firstNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            List<int> secondNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < firstNumbers.Count; i++)
            {
                while (secondNumbers.Contains(firstNumbers[i]))
                {
                    secondNumbers.Remove(firstNumbers[i]);
                }
            }

            int firstListSum = firstNumbers.Sum();
            int secondListSum = secondNumbers.Sum();

            int difference = Math.Abs(firstListSum - secondListSum);

            if (difference == 0)
            {
                Console.WriteLine($"Yes. Sum: {firstListSum}");
            }
            else
            {
                Console.WriteLine($"No. Diff: {difference}");
            }
        }
    }
}
