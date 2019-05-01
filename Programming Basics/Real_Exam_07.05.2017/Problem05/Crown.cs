using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem05
{
    class Crown
    {
        static void Main(string[] args)
        {

                        //      Input = 10;
                        //
                        //@        @        @
                        //**       *       **
                        //*.*     *.*     *.*
                        //*..*   *...*   *..*
                        //*...* *.....* *...*
                        //*....*.......*....*
                        //*.....***.***.....*
                        //*******************
                        //*******************
            
            int n = int.Parse(Console.ReadLine());

            // This draws the first row:
            Console.WriteLine("@{0}@{0}@", new string(' ', (2 * n - 4) / 2));

            int dots = 0;
            int middleDots = 0;
            int spaces = n - 3;

            // This loop draws the next (n / 2  - 1) rows:
            for (int i = 0; i < n / 2 - 1; i++)
            {
                if (i == 1)
                {
                    middleDots = 1;
                }
                if (i == 0)
                {
                    Console.WriteLine("*{0}*{1}*{2}{1}*{0}*", new string('.', dots), new string(' ', spaces), new string('.', middleDots));
                }
                else
                {
                    Console.WriteLine("*{0}*{1}*{2}*{1}*{0}*", new string('.', dots), new string(' ', spaces), new string('.', middleDots));
                }
                
                dots++;
                middleDots += 2;
                spaces -= 2;
            }

            // This draws the last four rows:
            Console.WriteLine("*{0}*{1}*{0}*", new string('.', dots), new string('.', middleDots));
            int middleStars = (middleDots - 1) / 2;
            dots++;
            Console.WriteLine("*{0}{1}.{1}{0}*", new string('.', dots), new string('*', middleStars));
            Console.WriteLine("{0}", new string('*', 2 * n - 1));
            Console.WriteLine("{0}", new string('*', 2 * n - 1));
        }
    }
}
