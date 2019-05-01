using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawFilledSquare
{
    class DrawFilledSquare
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintFirstLastRow(n);

            PrintsMiddleRows(n);

            PrintFirstLastRow(n);
        }

        static void PrintsMiddleRows(int n)
        {
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("-");
                for (int j = 0; j < n - 1; j++)
                {

                    Console.Write(@"\/");
                }
                Console.Write("-");
                Console.WriteLine();
            }
        }

        static void PrintFirstLastRow(int n)
        {
            Console.WriteLine(new string('-', 2 * n));
        }
    }
}
