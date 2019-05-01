using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddOccurrences
{
    class OddOccurrences
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsAndTheirValues = new Dictionary<string, int>();

            string[] words = Console.ReadLine().ToLower().Split(' ').ToArray();

            for (int i = 0; i < words.Length; i++)
            {
                if (wordsAndTheirValues.ContainsKey(words[i]))
                {
                    wordsAndTheirValues[words[i]]++;
                }
                else
                {
                    wordsAndTheirValues[words[i]] = 1;
                }
            }

            List<string> results = new List<string>();

            foreach (var item in wordsAndTheirValues)
            {
                if (item.Value % 2 != 0)
                {
                    results.Add(item.Key);
                }
            }

            Console.WriteLine(string.Join(", ", results));
        }
    }
}
