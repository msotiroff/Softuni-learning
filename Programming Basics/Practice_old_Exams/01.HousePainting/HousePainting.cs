using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.HousePainting
{
    class HousePainting
    {
        static void Main(string[] args)
        {
            double houseSideX = double.Parse(Console.ReadLine());
            double houseSideY = double.Parse(Console.ReadLine());
            double roofSideH = double.Parse(Console.ReadLine());

            double frontAndRear = houseSideX * houseSideX * 2 - 2 * 1.2;
            double sides = 2 * (houseSideX * houseSideY - 1.5 * 1.5);
            double sidesOfRoof = 2 * (houseSideX * houseSideY);
            double frontAndRearOfRoof = 2 * (houseSideX * roofSideH / 2);

            double greenPaint = (frontAndRear + sides) / 3.4;
            double redPaint = (sidesOfRoof + frontAndRearOfRoof) / 4.3;

            Console.WriteLine("{0:f2}", greenPaint);
            Console.WriteLine("{0:f2}", redPaint);
        }
    }
}
