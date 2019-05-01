using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Boxes
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            int distanceX = Math.Abs(firstPoint.X - secondPoint.X);
            int distanceY = Math.Abs(firstPoint.Y - secondPoint.Y);

            double realDistance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

            return realDistance;
        }
    }
}
