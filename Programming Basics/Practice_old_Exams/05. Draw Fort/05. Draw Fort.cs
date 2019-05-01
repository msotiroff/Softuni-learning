using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Draw_Fort
{
    class Program
    {
        static void Main(string[] args)
        {
            // /^^\__ /^^\
            // |         |
            // |         |
            // |    __   |
            // \__ /  \__/

            int n = int.Parse(Console.ReadLine());
            int columnsInside = n / 2;
            // Draws the first row:
             Console.WriteLine("/{0}\\{1}/{0}\\", new string('^', n / 2), new string('_', 2 * n - 2 * columnsInside - 4));

            // Draws the middle(n-2) rows:
            for (int i = 1; i <= n - 2; i++)
            {
                if (i == n - 2)
                {
                    Console.WriteLine("|{0}{1}{0}|", new string(' ', n / 2 + 1), new string('_', 2 * n - 2 * columnsInside - 4));
                }
                else
                {
                    Console.WriteLine("|{0}|", new string(' ', 2 * n - 2));
                }
            }

            // Draws the last row:
            Console.WriteLine("\\{0}/{1}\\{0}/", new string('_', n / 2), new string(' ', 2 * n - 2 * columnsInside - 4));
        }
    }
}
