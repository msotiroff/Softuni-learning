using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Distance_Between_Points
{
    public class DistanceBetweenPoints
    {
        public static void Main(string[] args)
        {
            Point firstPoint = GetPoint();
            Point secondPoint = GetPoint();

            double distance = CalculateDistance(firstPoint, secondPoint);

            Console.WriteLine($"{distance:f3}");
        }

        public static double CalculateDistance(Point firstPoint, Point secondPoint)
        {
            int distanceX = Math.Abs(firstPoint.X - secondPoint.X);
            int distanceY = Math.Abs(firstPoint.Y - secondPoint.Y);

            double realDistance = Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

            return realDistance;
        }

        public static Point GetPoint()
        {
            int[] pointCoordinates = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            Point currentPoint = new Point();
            currentPoint.X = pointCoordinates[0];
            currentPoint.Y = pointCoordinates[1];

            return currentPoint;
        }
    }
}
