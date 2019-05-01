using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfectDiamond
{
    class PerfectDiamond
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            if (n == 1)
            {
                Console.WriteLine("*");
            }
            else
            {
                // Draws the upper part of diamond:
                int spaces = n - 1;
                Console.WriteLine("{0}*", new string(' ', spaces));
                spaces--;
                for (int i = 1; i <= n - 1; i++)
                {
                    Console.Write("{0}*", new string(' ', spaces));
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write("-*");
                    }
                    Console.WriteLine();
                    spaces--;
                }
                spaces = 1;
                // Draws the down part of diamond:
                for (int i = 1; i <= n - 2; i++)
                {
                    Console.Write("{0}*", new string(' ', spaces));
                    spaces++;
                    for (int j = 1; j <= n - i - 1; j++)
                    {
                        Console.Write("-*");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("{0}*", new string(' ', spaces));

            }

        }
    }
}
