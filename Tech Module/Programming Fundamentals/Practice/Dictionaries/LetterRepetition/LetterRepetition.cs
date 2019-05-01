using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetterRepetition
{
    class LetterRepetition
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();

            Dictionary<char, int> resultValues = new Dictionary<char, int>();

            for (int i = 0; i < words.Length; i++)
            {
                if (resultValues.ContainsKey(words[i]))
                {
                    resultValues[words[i]]++;
                }
                else
                {
                    resultValues[words[i]] = 1;
                }
            }

            foreach (var item in resultValues)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            } 

        }
    }
}
