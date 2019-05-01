using System;

namespace _9.Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine().ToLower();

            decimal area = 0;

            if (figure == "square")
            {
                decimal side = decimal.Parse(Console.ReadLine());
                area = side * side;
            }
            else if (figure == "circle")
            {
                decimal radius = decimal.Parse(Console.ReadLine());
                area = radius * radius * (decimal)Math.PI;
            }
            else if (figure == "triangle")
            {
                decimal side = decimal.Parse(Console.ReadLine());
                decimal height = decimal.Parse(Console.ReadLine());
                area = side * height / 2;
            }
            else if (figure == "rectangle")
            {
                decimal sideA = decimal.Parse(Console.ReadLine());
                decimal sideB = decimal.Parse(Console.ReadLine());
                area = sideA * sideB;
            }

            Console.WriteLine($"{area:f2}");

        }
    }
}
