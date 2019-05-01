using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortNumbers
{
    class SortNumbers
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .ToList();

            numbers.Sort();

            Console.WriteLine("{0}", string.Join(" <= ", numbers));
        }
    }
}
