using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveNegativesAndReverse
{
    class RemoveNegativesAndReverse
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            numbers.Reverse();

            int listSum = numbers.Sum();

            if (listSum == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                foreach (var item in numbers)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
