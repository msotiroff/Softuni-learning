using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Rectangle_Area
{
    public class RectangleArea
    {
        public static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());

            double rectangleArea = sideA * sideB;

            Console.WriteLine($"{rectangleArea:f2}");
        }
    }
}
