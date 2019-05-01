using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MagicNumbers
{
    class MagicNumbers
    {
        static void Main(string[] args)
        {
            int magicNumber = int.Parse(Console.ReadLine());

            for (int digitOne = 1; digitOne <= 9; digitOne++)
            {
                for (int digitTwo = 1; digitTwo <= 9; digitTwo++)
                {
                    for (int digitThree = 1; digitThree <= 9; digitThree++)
                    {
                        for (int digitFour = 1; digitFour <= 9; digitFour++)
                        {
                            for (int digitFive = 1; digitFive <= 9; digitFive++)
                            {
                                for (int digitSix = 1; digitSix <= 9; digitSix++)
                                {
                                    int multiplication = digitOne * digitTwo * digitThree * digitFour * digitFive * digitSix;
                                    if (multiplication == magicNumber)
                                    {
                                        Console.Write("{0}{1}{2}{3}{4}{5} ", digitOne, digitTwo, digitThree, digitFour, digitFive, digitSix);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
