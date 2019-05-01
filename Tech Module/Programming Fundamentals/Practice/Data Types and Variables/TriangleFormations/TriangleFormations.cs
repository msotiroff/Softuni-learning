using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleFormations
{
    class TriangleFormations
    {
        static void Main(string[] args)
        {
            // Input the potentially triangle's sides:
            int sideA = int.Parse(Console.ReadLine());
            int sideB = int.Parse(Console.ReadLine());
            int sideC = int.Parse(Console.ReadLine());

            if (sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA)
            {
                Console.WriteLine("Triangle is valid.");
            }
            else
            {
                Console.WriteLine("Invalid Triangle.");
                return;
            }

            if (sideA * sideA + sideB * sideB == sideC * sideC)
            {
                Console.WriteLine("Triangle has a right angle between sides a and b");
            }
            else if (sideA * sideA + sideC * sideC == sideB * sideB)
            {
                Console.WriteLine("Triangle has a right angle between sides a and c");
            }
            else if (sideB * sideB + sideC * sideC == sideA * sideA)
            {
                Console.WriteLine("Triangle has a right angle between sides b and c");
            }
            else
            {
                Console.WriteLine("Triangle has no right angles");
            }
        }
    }
}
