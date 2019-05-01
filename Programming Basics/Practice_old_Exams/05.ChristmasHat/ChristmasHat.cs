using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ChristmasHat
{
    class ChristmasHat
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int dots = 2 * n - 1;
            int dashes = 0;

            // Draws the first two rows:
            Console.WriteLine("{0}/|\\{0}", new string('.', dots));
            Console.WriteLine("{0}\\|/{0}", new string('.', dots));

            // This loop draws the next 2 * n rows:
            for (int i = 0; i < 2 * n; i++)
            {
                Console.WriteLine("{0}*{1}*{1}*{0}", new string('.', dots), new string('-', dashes));
                dots--;
                dashes++;
            }

            // This draws the last 3 rows:
            Console.WriteLine("{0}", new string('*', 4 * n + 1));
            for (int i = 0; i < 2 * n; i++)
            {
                Console.Write("*.");
            }
            Console.WriteLine("*");
            Console.WriteLine("{0}", new string('*', 4 * n + 1));

        }
    }
}
