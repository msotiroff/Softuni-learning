using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Boxes
{
    public class Box
    {
        public Point UpperLeftPoint { get; set; }
        public Point UpperRightPoint { get; set; }
        public Point BottomLeftPoint { get; set; }
        public Point BottomRightPoint { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double Perimeter { get; set; }
        public double Area { get; set; }

        public static double CalculatePerimeter(double width, double height)
        {
            double perimeter = 2 * (width + height);
            return perimeter;
        }
        public static double CalculateArea(double width, double height)
        {
            double area = width * height;
            return area;
        }
    }
}
