using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallestElementInArray
{
    class SmallestElementInArray
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int smallestElement = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < smallestElement)
                {
                    smallestElement = numbers[i];
                }
            }
            Console.WriteLine(smallestElement);
        }
    }
}
