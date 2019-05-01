using System;

namespace _7.Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double a1 = double.Parse(Console.ReadLine());
            double b1 = double.Parse(Console.ReadLine());
            double a2 = double.Parse(Console.ReadLine());
            double b2 = double.Parse(Console.ReadLine());


            PrintResult(x1, y1, x2, y2, a1, b1, a2, b2);

        }

        public static void PrintResult(double x1, double y1, double x2, double y2, double a1, double b1, double a2, double b2)
        {
            double firstLine = GetLineLenght(x1, y1, x2, y2);
            double secondLine = GetLineLenght(a1, b1, a2, b2);

            if (firstLine >= secondLine)
            {
                    double firstPointDistanceToZero = GetLineLenght(x1, y1, 0, 0);
                    double secondPointDistanceToZero = GetLineLenght(x2, y2, 0, 0);
                    if (firstPointDistanceToZero <= secondPointDistanceToZero)
                    {
                        Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                    }
                    else
                    {
                        Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                    }
            }
            else
            {
                    double firstPointDistanceToZero = GetLineLenght(a1, b1, 0, 0);
                    double secondPointDistanceToZero = GetLineLenght(a2, b2, 0, 0);
                    if (firstPointDistanceToZero <= secondPointDistanceToZero)
                    {
                        Console.WriteLine($"({a1}, {b1})({a2}, {b2})");
                    }
                    else
                    {
                        Console.WriteLine($"({a2}, {b2})({a1}, {b1})");
                    }
            }
        }

        public static double GetLineLenght(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            return distance;
        }

    }
}
