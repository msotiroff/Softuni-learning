namespace P11.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Palindromes
    {
        public static void Main(string[] args)
        {
            var allPalindroms = new HashSet<string>();

            var separators = new char[] { ' ', '.', ',', '!', '?' };

            var input = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in input)
            {
                var isPalindrom = true;

                for (int i = 0; i < word.Length / 2; i++)
                {
                    if (word[i] != word[word.Length - 1 - i])
                    {
                        isPalindrom = false;
                        break;
                    }
                }

                if (isPalindrom)
                {
                    allPalindroms.Add(word);
                }
            }

            var result = string.Format("[{0}]", string.Join(", ", allPalindroms.OrderBy(w => w)));

            Console.WriteLine(result);
        }
    }
}
