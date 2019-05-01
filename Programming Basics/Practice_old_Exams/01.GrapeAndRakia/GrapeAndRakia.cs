using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.GrapeAndRakia
{
    class GrapeAndRakia
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine());
            double kgPerSquare = double.Parse(Console.ReadLine());
            double waste = double.Parse(Console.ReadLine());

            double grape = area * kgPerSquare - waste;

            double grapeForRakia = grape * 0.45;
            double grapeForSale = grape * 0.55;

            double moneyByRakia = grapeForRakia / 7.5 * 9.8;
            double moneyByGrape = grapeForSale * 1.5;

            Console.WriteLine("{0:f2}", moneyByRakia);
            Console.WriteLine("{0:f2}", moneyByGrape);

        }
    }
}
