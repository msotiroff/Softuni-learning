using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitByWordCasing
{
    class SplitByWordCasing
    {
        static void Main(string[] args)
        {
            char[] splitSymbols = { ',', ';', ':', '.', '!', '(', ')', '"', '/', '\\', '[', ']', ' ', '\u0027' };
            List<string> words = Console.ReadLine()
                .Split(splitSymbols, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> lowerCase = new List<string>();
            List<string> mixedCase = new List<string>();
            List<string> upperCase = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                int upperSymbols = 0;
                int lowerSymbols = 0;
                int mixedSymbols = 0;

                foreach (char symbol in words[i])
                {
                    if (char.IsUpper(symbol))
                    {
                        upperSymbols++;
                    }
                    else if (char.IsLower(symbol))
                    {
                        lowerSymbols++;
                    }
                    else if (char.IsLetter(symbol) == false)
                    {
                        mixedSymbols++;
                    }
                }
                
                if (mixedSymbols > 0)
                {
                    mixedCase.Add(words[i]);
                }
                else
                {
                    if (upperSymbols > 0 && lowerSymbols > 0)
                    {
                        mixedCase.Add(words[i]);
                    }
                    else if (upperSymbols > 0 && lowerSymbols == 0)
                    {
                        upperCase.Add(words[i]);
                    }
                    else if (upperSymbols == 0 && lowerSymbols > 0)
                    {
                        lowerCase.Add(words[i]);
                    }
                }
            }

            Console.WriteLine("Lower-case: {0}", string.Join(", ", lowerCase));
            Console.WriteLine("Mixed-case: {0}", string.Join(", ", mixedCase));
            Console.WriteLine("Upper-case: {0}", string.Join(", ", upperCase));

        }
    }
}
