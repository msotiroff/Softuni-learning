using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Hourglass
{
    class Hourglass
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // This draws the first two rows:
            Console.WriteLine("{0}", new string('*', 2 * n + 1));
            Console.WriteLine(".*{0}*.", new string(' ', 2 * n - 3));

            int dots = 2;
            int monkeys = 2 * n - 5;

            // This loop draws the top of hourglass:
            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', dots), new string('@', monkeys));
                dots++;
                monkeys -= 2;
            }

            // This draws the middle row:
            Console.WriteLine("{0}*{0}", new string('.', dots));

            int spaces = 0;
            dots--;

            // This loop draws the bottom of hourglass:
            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine("{0}*{1}@{1}*{0}", new string('.', dots), new string(' ', spaces));
                dots--;
                spaces++;
            }

            // This draws the last two rows:
            Console.WriteLine(".*{0}*.", new string('@', 2 * n - 3));
            Console.WriteLine("{0}", new string('*', 2 * n + 1));
        }
    }
}
