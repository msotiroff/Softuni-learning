
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Rocket
{
    class Rocket
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int dots = (3 * n - 2) / 2;
            int spaces = 0;

            // This loop draws the first n rows of the rocket:
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}/{1}\\{0}", new string('.', dots), new string(' ', spaces));
                dots--;
                spaces += 2;
            }

            // This draws the middle line:
            dots++;
            Console.WriteLine("{0}{1}{0}", new string('.', dots), new string('*', spaces));
            spaces -= 2;

            // This loop draws the next 2 * n rows:
            for (int i = 0; i < 2 * n; i++)
            {
                Console.WriteLine("{0}|{1}|{0}", new string('.', dots), new string('\\', spaces));
            }

            // This loop draws the last n / 2 rows:
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}/{1}\\{0}", new string('.', dots), new string('*', spaces));
                dots--;
                spaces += 2;
            }
        }
    }
}
