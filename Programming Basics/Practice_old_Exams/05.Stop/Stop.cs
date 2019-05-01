using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Stop
{
    class Stop
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int dots = n + 1;
            int dashes = 2 * n + 1;

            // Draws the first row:
            Console.WriteLine("{0}{1}{0}", new string('.', dots), new string('_', dashes));

            // Draws the next n + 1 rows:
            dots--;
            dashes -= 2;
            for (int i = 0; i < n + 1; i++)
            {
                if (i == n)
                {
                    Console.WriteLine("//{0}STOP!{0}\\\\", new string('_', (dashes - 5) / 2));
                }
                else
                {
                    Console.WriteLine("{0}//{1}\\\\{0}", new string('.', dots), new string('_', dashes));
                }
                dots--;
                dashes += 2;
            }

            // draws teh next n rows:
            dots++;
            dashes -= 2;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}\\\\{1}//{0}", new string('.', dots), new string('_', dashes));
                dots++;
                dashes -= 2;
            }


        }
    }
}
