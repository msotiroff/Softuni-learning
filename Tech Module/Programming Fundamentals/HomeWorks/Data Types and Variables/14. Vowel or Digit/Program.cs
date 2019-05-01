using System;
using System.Collections.Generic;

namespace _14.Vowel_or_Digit
{
    class VowelOrDigit
    {
        static void Main(string[] args)
        {
            char inputSymbol = char.Parse(Console.ReadLine());
            List<char> vowels = new List<char>
            {
                'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y'
            };

            string result = string.Empty;

            if (char.IsDigit(inputSymbol))
            {
                result = "digit";
            }
            else if (vowels.Contains(inputSymbol))
            {
                result = "vowel";
            }
            else
            {
                result = "other";
            }

            Console.WriteLine(result);
        }
    }
}
