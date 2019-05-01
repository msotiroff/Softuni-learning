using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Largest_3_Numbers
{
    public class Largest_3_Numbers
    {
        public static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(n => int.Parse(n))
                .ToList();

            List<int> largestThree = numbers.
                OrderByDescending(n => n)
                .Take(3)
                .ToList();

            Console.WriteLine(string.Join(" ", largestThree));

        }
    }
}
