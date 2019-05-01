using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Odd_Occurrences
{
    class OddOccurrences
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .ToLower()
                .Split(' ')
                .ToArray();

            Dictionary<string, int> countedUniqueWords =
                new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string currentWord = words[i];
                if (! countedUniqueWords.ContainsKey(currentWord))
                {
                    countedUniqueWords[currentWord] = 1;
                }
                else
                {
                    countedUniqueWords[currentWord]++;
                }
            }

            countedUniqueWords = 
                countedUniqueWords
                .Where(x => x.Value % 2 != 0)
                .ToDictionary(x => x.Key, x => x.Value);

            
                Console.WriteLine(string.Join(", ", countedUniqueWords.Keys));
            
        }
    }
}
