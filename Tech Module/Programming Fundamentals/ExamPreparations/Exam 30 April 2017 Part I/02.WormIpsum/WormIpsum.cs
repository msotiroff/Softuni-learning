using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.WormIpsum
{
    class WormIpsum
    {
        static void Main(string[] args)
        {
            string inputSentence = Console.ReadLine();

            Regex validateSentence = new Regex(@"^[A-Z][^\.]+\.$");   //  ^[A-Z][\w,:;\-\s]*\.$      ^[A-Z][A-Za-z,\-\s]*\.$
            Regex getWords = new Regex(@"[A-z]+");


            while (inputSentence != "Worm Ipsum")
            {
                var matchedSentence = validateSentence.Match(inputSentence);

                if (matchedSentence.Success)
                {
                    var matchedWords = getWords.Matches(inputSentence);

                    foreach (Match word in matchedWords)
                    {
                        char neededChar = default(char);

                        if (word.ToString().Length > word.ToString().ToCharArray().Distinct().Count())
                        {
                            int maxCount = 0;

                            for (int i = 0; i < word.ToString().Length; i++)
                            {
                                char currentLetter = word.ToString()[i];
                                int counter = word.ToString().Count(x => x == currentLetter);
                                if (counter > maxCount)
                                {
                                    maxCount = counter;
                                    neededChar = currentLetter;
                                }
                            }

                            if (maxCount > 1)
                            {
                                string wordToReplace = new string(neededChar, word.ToString().Length);
                                inputSentence = Regex.Replace(inputSentence, word.ToString(), wordToReplace);
                            }
                        }
                    }
                    
                    Console.WriteLine(inputSentence);
                }

                inputSentence = Console.ReadLine();
            }


        }
    }
}
