using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Butterfly
{
    class Butterfly
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int elements = n - 2;

            // Draws the top of picture:
            for (int i = 1; i <= n - 2; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("{0}\\ /{0}", new string('*', elements));
                }
                else
                {
                    Console.WriteLine("{0}\\ /{0}", new string('-', elements));
                }
            }

            // Draws the middle line of picture:
            Console.WriteLine("{0}@{0}", new string(' ', elements + 1));

            // Draws the bottom of picture:
            for (int i = 1; i <= n - 2; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("{0}/ \\{0}", new string('*', elements));
                }
                else
                {
                    Console.WriteLine("{0}/ \\{0}", new string('-', elements));
                }
            }
        }
    }
}
