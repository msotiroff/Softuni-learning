using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastThreeConsecutiveEqualStrings
{
    class LastThreeConsecutiveEqualStrings
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ').ToArray();

            int counter = 1;
            for (int i = words.Length - 1; i > 0; i--)
            {
                if (words[i] == words[i - 1])
                {
                    counter++;
                    if (counter == 3)
                    {
                        Console.WriteLine($"{words[i]} {words[i]} {words[i]}");
                        break;
                    }
                }
                else
                {
                    counter = 1;
                }
            }

        }
    }
}
