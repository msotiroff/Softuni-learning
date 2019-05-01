using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputWords = Console.ReadLine()
                .Split(new[] { ' ', '.', ',', '?', '!', '-' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<string> palindromes = new List<string>();

            for (int i = 0; i < inputWords.Length; i++)
            {
                string currentWord = inputWords[i];
                string revercedWord = ReverseThisWord(currentWord);

                if (currentWord == revercedWord)
                {
                    palindromes.Add(currentWord);
                }
            }

            palindromes = palindromes.Distinct().OrderBy(x => x).ToList();

            Console.WriteLine(string.Join(", ", palindromes));
        }
        public static string ReverseThisWord(string word)
        {
            string revercedWord = string.Empty;
            for (int i = word.Length - 1; i >= 0; i--)
            {
                revercedWord += word[i];
            }

            return revercedWord;
        }
    }
}
