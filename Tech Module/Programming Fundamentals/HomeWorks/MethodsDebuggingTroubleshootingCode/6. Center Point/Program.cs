using System;

namespace _6.Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            Console.WriteLine(MinDistancePoint(x1, y1, x2, y2));
        }

        private static string MinDistancePoint(double x1, double y1, double x2, double y2)
        {
            double firstPointDistance = Math.Sqrt(x1 * x1 + y1 * y1);
            double seconPointDistance = Math.Sqrt(x2 * x2 + y2 * y2);
            string result = string.Empty;

            if (firstPointDistance <= seconPointDistance)
            {
                result = $"({x1}, {y1})";
            }
            else
            {
                result = $"({x2}, {y2})";
            }

            return result;
        }
    }
}
