using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw_a_X
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int outSpaces = 0;
            int inSpaces = n - 2;

            // This loop draws the upper n / 2 rows:
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}x{1}x{0}", new string(' ', outSpaces), new string(' ', inSpaces));
                outSpaces++;
                inSpaces -= 2;
            }

            // This draws the middle row:
            Console.WriteLine("{0}x{0}", new string(' ', outSpaces));

            outSpaces--;
            inSpaces += 2;

            // This loop draws the down n/2 rows:
            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{0}x{1}x{0}", new string(' ', outSpaces), new string(' ', inSpaces));
                outSpaces--;
                inSpaces += 2;
            }
        }
    }
}
