using System;

namespace _3.Water_Overflow
{
    class WaterOverflow
    {
        static void Main(string[] args)
        {
            int inputLines = int.Parse(Console.ReadLine());

            int waterTank = 0;

            for (int i = 0; i < inputLines; i++)
            {
                int currentLiters = int.Parse(Console.ReadLine());
                if (waterTank + currentLiters > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    waterTank += currentLiters;
                }
            }

            Console.WriteLine(waterTank);
        }
    }
}
