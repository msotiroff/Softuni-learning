using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayElementsEqualToTheirIndex
{
    class ArrayElementsEqualToTheirIndex
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                            .Split(' ')
                            .Select(int.Parse)
                            .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers[i])
                {
                    Console.Write(i + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
