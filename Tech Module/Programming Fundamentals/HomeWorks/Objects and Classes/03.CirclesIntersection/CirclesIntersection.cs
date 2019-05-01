using System;
using System.Linq;

namespace _03.CirclesIntersection
{
    public class CirclesIntersection
    {
        static void Main(string[] args)
        {
            //  Input format: {X} {Y} {Radius}

            int[] firstCircleProps = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] secondCircleProps = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Point firstCircleCenter = ReadPoint(firstCircleProps[0], firstCircleProps[1]);
            Point secondCircleCenter = ReadPoint(secondCircleProps[0], secondCircleProps[1]);

            Circle firstCircle = new Circle()
            {
                Center = firstCircleCenter,
                Radius = firstCircleProps[2]
            };
            Circle secondCircle = new Circle()
            {
                Center = secondCircleCenter,
                Radius = secondCircleProps[2]
            };

            double distanceBetweenRaduises = GetDistance(firstCircle.Center, secondCircle.Center);

            bool circlesCovered = 
                Intersect(distanceBetweenRaduises, firstCircle.Radius, secondCircle.Radius);

            Console.WriteLine(circlesCovered ? "Yes" : "No");


        }

        public static bool Intersect(double distance, int radiusOne, int radiusTwo)
        {
            bool isInside = false;
            if (distance <= radiusOne + radiusTwo)
            {
                isInside = true;
            }

            return isInside;
        }

        public static double GetDistance(Point center1, Point center2)
        {
            double xDistance = (center1.X - center2.X) * (center1.X - center2.X);
            double yDistance = (center1.Y - center2.Y) * (center1.Y - center2.Y);

            double distance = Math.Sqrt(xDistance + yDistance);

            return distance;
        }

        public static Point ReadPoint(int x, int y)
        {
            Point center = new Point();
            center.X = x;
            center.Y = y;

            return center;
        }
    }
}
