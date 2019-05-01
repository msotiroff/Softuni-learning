using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DogHouse
{
    class DogHouse
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double houseHeight = double.Parse(Console.ReadLine());

            double rearSides = sideA * sideA;
            double backSide = sideA * sideA / 4 + (sideA / 2 * (houseHeight - sideA / 2)) / 2;
            double frontSide = backSide - sideA / 5 * sideA / 5;

            double greenPaint = (rearSides + backSide + frontSide) / 3;

            double roof = 2 * (sideA * sideA / 2);

            double redPaint = roof / 5;

            Console.WriteLine($"{greenPaint:f2}");
            Console.WriteLine($"{redPaint:f2}");
        }
    }
}
