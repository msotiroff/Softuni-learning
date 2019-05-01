using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.OddFilter
{
    class OddFilter
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            numbers = numbers.Where(x => x % 2 == 0).ToList();

            double average = numbers.Average();

            numbers = numbers.Select(x => x > average ? x + 1 : x - 1).ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
