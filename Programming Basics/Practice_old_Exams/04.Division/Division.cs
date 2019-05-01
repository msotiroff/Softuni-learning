using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Division
{
    class Division
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int divideByTwo = 0;
            int divideByThree = 0;
            int divideByFour = 0;

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number % 2 == 0)
                {
                    divideByTwo++;
                }
                if (number % 3 == 0)
                {
                    divideByThree++;
                }
                if (number % 4 == 0)
                {
                    divideByFour++;
                }
            }

            Console.WriteLine("{0:f2}%", (double)divideByTwo / n * 100);
            Console.WriteLine("{0:f2}%", (double)divideByThree / n * 100);
            Console.WriteLine("{0:f2}%", (double)divideByFour / n * 100);
        }
    }
}

