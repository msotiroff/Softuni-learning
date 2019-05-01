using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.FiveDifferentNumbers
{
    class FiveDifferentNumbers
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            if (b - a < 4)
            {
                Console.WriteLine("No");
            }
            else
            {
                for (int dig1 = a; dig1 <= b; dig1++)
                {
                    for (int dig2 = dig1 + 1; dig2 <= b; dig2++)
                    {
                        for (int dig3 = dig2 + 1; dig3 <= b; dig3++)
                        {
                            for (int dig4 = dig3 + 1; dig4 <= b; dig4++)
                            {
                                for (int dig5 = dig4 + 1; dig5 <= b; dig5++)
                                {
                                    Console.WriteLine($"{dig1} {dig2} {dig3} {dig4} {dig5}");
                                }
                            }
                        }
                    }
                }



            }

        }
    }
}
