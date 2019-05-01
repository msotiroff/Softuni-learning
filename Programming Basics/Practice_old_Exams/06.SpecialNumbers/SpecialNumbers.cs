
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int dig1 = 1; dig1 <= 9; dig1++)
            {
                for (int dig2 = 1; dig2 <= 9; dig2++)
                {
                    for (int dig3 = 1; dig3 <= 9; dig3++)
                    {
                        for (int dig4 = 1; dig4 <= 9; dig4++)
                        {
                            if (n % dig1 == 0 && n % dig2 == 0 && n % dig3 == 0 && n % dig4 == 0)
                            {
                                Console.Write($"{dig1}{dig2}{dig3}{dig4} ");
                            }
                        }
                    }
                }
            }

        }
    }
}
