using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.BombNumbers
{
    class BombNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            int[] bombProperties = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int bombNumber = bombProperties[0];
            int bombPower = bombProperties[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    int indexToStartDeleting = Math.Max(0, i - bombPower);
                    int indexToEndDeleting = Math.Min(numbers.Count - 1, i + bombPower);
                    int difference = indexToEndDeleting - indexToStartDeleting + 1;

                    numbers.RemoveRange(indexToStartDeleting, difference);
                    i = 0;
                }
            }

            Console.WriteLine(numbers.Sum().ToString());
        }
    }
}
