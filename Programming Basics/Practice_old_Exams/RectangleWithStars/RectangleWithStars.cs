using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleWithStars
{
    class RectangleWithStars
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // Draws the first row:
            Console.WriteLine("{0}", new string('%', 2 * n));

            // Draws the middle n - 1 rows:
            int midRows = 0;
            if (n % 2 == 0)
            {
                midRows = n - 1;
            }
            else
            {
                midRows = n;
            }
            for (int i = 1; i <= midRows; i++)
            {
                if (i == (midRows + 1) / 2)
                {
                    Console.WriteLine("%{0}**{0}%", new string(' ', (2 * n - 4) / 2));
                }
                else
                {
                    Console.WriteLine("%{0}%", new string(' ', 2 * n - 2));
                }
            }
            // Draws the last row:
            Console.WriteLine("{0}", new string('%', 2 * n));
        }
    }
}
