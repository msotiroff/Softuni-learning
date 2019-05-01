using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Magic_Letter
{
    class MagicLetter
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char thirdLetter = char.Parse(Console.ReadLine());

            for (char startLetter = firstLetter; startLetter <= secondLetter; startLetter++)
            {
                for (char middleLetter = firstLetter; middleLetter <= secondLetter; middleLetter++)
                {
                    for (char endLetter = firstLetter; endLetter <= secondLetter; endLetter++)
                    {
                        if (startLetter != thirdLetter && middleLetter != thirdLetter && endLetter != thirdLetter)
                        {
                            Console.Write($"{startLetter}{middleLetter}{endLetter} ");
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
