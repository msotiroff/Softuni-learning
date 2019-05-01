using System;

namespace _13.Rectangle_Properties
{
    class RectangleProperties
    {
        static void Main(string[] args)
        {
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());

            double perimeter = 2 * (sideA + sideB);
            double area = sideA * sideB;
            double diagonal = Math.Sqrt(sideA * sideA + sideB * sideB);

            Console.WriteLine(perimeter);
            Console.WriteLine(area);
            Console.WriteLine(diagonal);
        }
    }
}
