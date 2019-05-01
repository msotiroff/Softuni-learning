using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Diamond
{
    class Diamond
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int outDots = n;
            int inDots = 3 * n;
            // This draws the first row:
            Console.WriteLine("{0}{1}{0}", new string('.', outDots), new string('*', 3 * n));

            // This loop draws the next n - 1 rows:
            outDots--;
            for (int i = 0; i < n - 1; i++)
            {
                Console.WriteLine("{0}*{1}*{0}", new string('.', outDots), new string('.', inDots));
                outDots--;
                inDots += 2;
            }

            // This draws the middle row of diamond:
            Console.WriteLine("{0}", new string('*', 5 * n));

            // This loop draws the downside of diamond(n rows):
            for (int i = 0; i < 2 * n; i++)
            {
                outDots++;
                inDots -= 2;
                Console.WriteLine("{0}*{1}*{0}", new string('.', outDots), new string('.', inDots));
            }
            outDots++;
            inDots -= 2;
            // This draws the last row:
            Console.WriteLine("{0}*{1}*{0}", new string('.', outDots), new string('*', inDots));
        }
    }
}
