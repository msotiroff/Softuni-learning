using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Closest_Two_Points
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Point[] allPoints = new Point[n];

            for (int i = 0; i < n; i++)
            {
                Point currentPoint = GetPoint();
                allPoints[i] = currentPoint;
            }

            double minDistance = double.MaxValue;
            Point firstMinPoint = new Point();
            Point secondMinPoint = new Point();

            for (int i = 0; i < allPoints.Length - 1; i++)
            {
                for (int j = i + 1; j < allPoints.Length; j++)
                {
                    Point firstPointToCheck = allPoints[i];
                    Point secondPointToCheck = allPoints[j];

                    double currentDistance = CalculateDistance(firstPointToCheck, secondPointToCheck);
                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        firstMinPoint = allPoints[i];
                        secondMinPoint = allPoints[j];
                    }
                }
            }

            Console.WriteLine($"{minDistance:f3}");
            Console.WriteLine($"({firstMinPoint.X}, {firstMinPoint.Y})");
            Console.WriteLine($"({secondMinPoint.X}, {secondMinPoint.Y})");
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
