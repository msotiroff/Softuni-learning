using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Fold_and_Sum
{
    class FoldAndSum
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int k = numbers.Count / 4;

            List<int> upRowLeft = numbers
                .Take(k)
                .Reverse()
                .ToList();
            List<int> upRowRight = numbers
                .Skip(3 * k)
                .Take(k)
                .Reverse()
                .ToList();

            List<int> upWholeRow = 
                upRowLeft.Concat(upRowRight).ToList();

            List<int> downRow = numbers
                .Skip(k)
                .Take(2 * k)
                .ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < downRow.Count; i++)
            {
                result.Add(upWholeRow[i] + downRow[i]);
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
