using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.GameOfIntervals
{
    class GameOfIntervals
    {
        static void Main(string[] args)
        {
            int gameMoves = int.Parse(Console.ReadLine());

            int num0to9 = 0;
            int num10to19 = 0;
            int num20to29 = 0;
            int num30to39 = 0;
            int num40to50 = 0;
            int invalidNumbers = 0;

            double result = 0;

            for (int i = 0; i < gameMoves; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 0 || currentNumber > 50)
                {
                    invalidNumbers++;
                    result /= 2;
                }
                else if (currentNumber < 10)
                {
                    num0to9++;
                    result += currentNumber * 0.2;
                }
                else if (currentNumber < 20)
                {
                    num10to19++;
                    result += currentNumber * 0.3;
                }
                else if (currentNumber < 30)
                {
                    num20to29++;
                    result += currentNumber * 0.4;
                }
                else if (currentNumber < 40)
                {
                    num30to39++;
                    result += 50;
                }
                else if (currentNumber <= 50)
                {
                    num40to50++;
                    result += 100;
                }
            }

            Console.WriteLine($"{result:f2}");
            Console.WriteLine($"From 0 to 9: {1.0 * num0to9 / gameMoves * 100:f2}%");
            Console.WriteLine($"From 10 to 19: {1.0 * num10to19 / gameMoves * 100:f2}%");
            Console.WriteLine($"From 20 to 29: {1.0 * num20to29 / gameMoves * 100:f2}%");
            Console.WriteLine($"From 30 to 39: {1.0 * num30to39 / gameMoves * 100:f2}%");
            Console.WriteLine($"From 40 to 50: {1.0 * num40to50 / gameMoves * 100:f2}%");
            Console.WriteLine($"Invalid numbers: {1.0 * invalidNumbers / gameMoves * 100:f2}%");
        }
}
}
