using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipListSides
{
    class FlipListSides
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int firstIndexNumber = numbers[0];

            numbers[0] = numbers[numbers.Count - 1];
            numbers[numbers.Count - 1] = firstIndexNumber;

            numbers.Reverse();

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
