using System;

namespace _01.Wormtest
{
    class Wormtest
    {
        static void Main(string[] args)
        {
            long wormLenght = long.Parse(Console.ReadLine()) * 100;     //  in centimeters
            double width = double.Parse(Console.ReadLine());            //  in centimeters

            if (width == 0)
            {
                Console.WriteLine($"{wormLenght * width:f2}");
                return;
            }
            double result = wormLenght / width;
            double reminder = wormLenght % width;

            if (reminder == 0)
            {
                Console.WriteLine($"{wormLenght * width:f2}");
            }
            else
            {
                Console.WriteLine($"{result * 100:f2}%");
            }
        }
    }
}
