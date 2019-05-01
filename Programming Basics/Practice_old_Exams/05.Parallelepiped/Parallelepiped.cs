using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Parallelepiped
{
    class Parallelepiped
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int waves = n - 2;
            int outDots = 2 * n + 1;
            int inDots = 0;

            // This draws the first row:
            Console.WriteLine("+{0}+{1}", new string('~', waves), new string('.', outDots));
            outDots--;
            // This loop draws the next (2 * n + 1) rows
            for (int i = 0; i < 2 * n + 1; i++)
            {
                Console.WriteLine("|{0}\\{1}\\{2}", new string('.', inDots), new string('~', waves), new string('.', outDots));
                inDots++;
                outDots--;
            }
            outDots++;
            inDots--;
            // This loop draws another (2 * n + 1) rows:

            for (int i = 0; i < 2 * n + 1; i++)
            {
                Console.WriteLine("{0}\\{1}|{2}|", new string('.', outDots), new string('.', inDots), new string('~', waves));
                outDots++;
                inDots--;
            }

            // This draws the last row:
            Console.WriteLine("{0}+{1}+", new string('.', outDots), new string('~', waves));
        }
    }
}
