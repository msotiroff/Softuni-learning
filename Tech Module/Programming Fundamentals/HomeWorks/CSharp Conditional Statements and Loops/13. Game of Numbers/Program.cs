using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Game_of_Numbers
{
    class GameOfNumbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int counter = 0;
            int lastDigitOne = 0;
            int lastDigitTwo = 0;
            bool magicNumberFound = false;

            for (int digitOne = n; digitOne <= m; digitOne++)
            {
                for (int digitTwo = n; digitTwo <= m; digitTwo++)
                {
                    counter++;
                    if (digitOne + digitTwo == magicNumber)
                    {
                        lastDigitOne = digitOne;
                        lastDigitTwo = digitTwo;
                        magicNumberFound = true;
                    }
                }
            }

            if (magicNumberFound)
            {
                Console.WriteLine($"Number found! {lastDigitOne} + {lastDigitTwo} = {magicNumber}");
            }
            else
            {
                Console.WriteLine($"{counter} combinations - neither equals {magicNumber}");
            }

        }
    }
}
