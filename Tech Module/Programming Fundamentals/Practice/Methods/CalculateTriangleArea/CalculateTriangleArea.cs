using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateTriangleArea
{
    class CalculateTriangleArea
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            TriangleArea(width, height);

        }

        static double TriangleArea(double width, double height)
        {
            double area = width * height / 2;
            Console.WriteLine(area);
            return area;
        }
    }
}
