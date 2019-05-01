using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Axe
{
    class Axe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int leftDashes = 3 * n;
            int insideDashes = 0;
            int rightDashes = 2 * n - 2;

            // This loop draw the rows to the handle:

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}*{1}*{2}", new string('-', leftDashes), new string('-', insideDashes), new string('-', rightDashes));
                insideDashes++;
                rightDashes--;
            }

            // This loop draws the handle:
            insideDashes--;
            rightDashes++;
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}*{1}*{2}", new string('*', leftDashes), new string('-', insideDashes), new string('-', rightDashes));
            }

            // This loop draws the rows under the handle:
            for (int i = 1; i <= n / 2; i++)
            {
                if (i == n / 2)
                {
                    Console.WriteLine("{0}*{1}*{2}", new string('-', leftDashes), new string('*', insideDashes), new string('-', rightDashes));
                }
                else
                {
                    Console.WriteLine("{0}*{1}*{2}", new string('-', leftDashes), new string('-', insideDashes), new string('-', rightDashes));
                }
                leftDashes--;
                rightDashes--;
                insideDashes += 2;
            }
        }
    }
}
