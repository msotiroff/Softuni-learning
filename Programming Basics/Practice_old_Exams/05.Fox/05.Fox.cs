using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fox
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int stars = 1;
            int dashes = 2 * n - 1;

            // Draws the first n-rows:
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}\\{1}/{0}", new string('*', stars), new string('-', dashes));
                stars++;
                dashes -= 2;
            }

            // Draws the eye-area:
            int starsBetweenEyes = n;
            stars = n / 2;
            for (int i = 0; i < n / 3; i++)
            {
                Console.WriteLine("|{0}\\{1}/{0}|", new string('*', stars), new string('*', starsBetweenEyes));
                stars++;
                starsBetweenEyes -= 2;
            }

            // Draws the last n-rows:
            stars = 2 * n - 1;
            dashes = 1;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}\\{1}/{0}", new string('-', dashes), new string('*', stars));
                dashes++;
                stars -= 2;
            }
        }
    }
}
