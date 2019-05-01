using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SoftUniLogo
{
    class SoftUniLogo
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int dots = (12 * n - 6) / 2;
            int sharps = 1;

            // This loop draws the top of hat:
            for (int i = 0; i < 2 * n; i++)
            {
                Console.WriteLine("{0}{1}{0}", new string('.', dots), new string('#', sharps));
                dots -= 3;
                sharps += 6;
            }

            // This loop draws the next n - 2 rows:
            dots = 3;
            sharps -= 12;
            for (int i = 0; i < n - 2; i++)
            {
                Console.WriteLine("|{0}{1}{2}", new string('.', dots - 1), new string('#', sharps), new string('.', dots));
                dots += 3;
                sharps -= 6;
            }

            // This loop draws the last n rows:
            for (int i = 0; i < n; i++)
            {
                if (i == n - 1)
                {
                    Console.WriteLine("@{0}{1}{2}", new string('.', dots - 1), new string('#', sharps), new string('.', dots));
                }
                else
                {
                    Console.WriteLine("|{0}{1}{2}", new string('.', dots - 1), new string('#', sharps), new string('.', dots));
                }
            }
        }
    }
}
