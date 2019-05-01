using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfCapitalLettersInArray
{
    class CountOfCapitalLettersInArray
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(' ')
                .ToArray();

            int counter = 0;

            for (int i = 0; i < words.Length; i++)
            {
                char firstLetter = words[i][0];
                if (words[i].Length == 1 && firstLetter >= 65 && firstLetter <= 90)
                {
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}
