using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctList
{
    class DistinctList
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = i; j < numbers.Count - 1; j++)
                {
                    if (numbers[i] == numbers[j + 1])
                    {
                        numbers.RemoveAt(j + 1);
                        i = 0;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
