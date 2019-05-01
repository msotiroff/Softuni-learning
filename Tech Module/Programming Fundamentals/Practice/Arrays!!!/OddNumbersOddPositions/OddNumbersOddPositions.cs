using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumbersOddPositions
{
    class OddNumbersOddPositions
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 1; i < numbers.Length; i += 2)
            {
                if (numbers[i] % 2 != 0)
                {
                    Console.WriteLine($"Index {i} -> {numbers[i]}");
                }
            }

        }
    }
}

