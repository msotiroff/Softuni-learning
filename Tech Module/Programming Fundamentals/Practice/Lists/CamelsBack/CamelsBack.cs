using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelsBack
{
    class CamelsBack
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int camelBack = int.Parse(Console.ReadLine());

            int rounds = (numbers.Count - camelBack) / 2;

            for (int i = 1; i <= rounds; i++)
            {
                numbers.RemoveAt(0);
                numbers.RemoveAt(numbers.Count - 1);
            }

            if (rounds > 0)
            {
                Console.WriteLine($"{rounds} rounds");
                Console.WriteLine("remaining: {0}", string.Join(" ", numbers));
            }
            else
            {
                Console.WriteLine("already stable: {0}", string.Join(" ", numbers));
            }
        }
    }
}

