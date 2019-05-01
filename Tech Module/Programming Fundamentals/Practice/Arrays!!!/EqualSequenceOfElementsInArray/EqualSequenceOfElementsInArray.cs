using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualSequenceOfElementsInArray
{
    class EqualSequenceOfElementsInArray
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string result = "Yes";

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i + 1] != numbers[i])
                {
                    result = "No";
                }
            }

            Console.WriteLine(result);

        }
    }
}
