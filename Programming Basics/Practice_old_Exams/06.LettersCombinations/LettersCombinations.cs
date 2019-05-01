using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.LettersCombinations
{
    class LettersCombinations
    {
        static void Main(string[] args)
        {
            char startLetter = char.Parse(Console.ReadLine());
            char endLetter = char.Parse(Console.ReadLine());
            char missThisLetter = char.Parse(Console.ReadLine());

            int counter = 0;

            for (char ch1 = startLetter; ch1 <= endLetter; ch1++)
            {
                for (char ch2 = startLetter; ch2 <= endLetter; ch2++)
                {
                    for (char ch3 = startLetter; ch3 <= endLetter; ch3++)
                    {
                        if (ch1 != missThisLetter && ch2 != missThisLetter && ch3 != missThisLetter)
                        {
                            counter++;
                            Console.Write($"{ch1}{ch2}{ch3} ");
                        }
                    }
                }
            }
            Console.WriteLine(counter);

        }
    }
}
