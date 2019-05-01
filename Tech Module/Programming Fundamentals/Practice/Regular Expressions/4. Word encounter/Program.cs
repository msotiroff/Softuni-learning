using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _4.Word_encounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string validSequencesPattern = @"^[A-Z].*[.?!]$";

            string searchParameters = Console.ReadLine();
            char symbol = searchParameters[0];
            int number = int.Parse(searchParameters[1].ToString());
            
            string wordPattern = @"\w+";


            string inputLine = Console.ReadLine();

            List<string> wordsToPrint = new List<string>();

            while (inputLine != "end")
            {
                Regex sequenceStatus = new Regex(validSequencesPattern);
                var currentStatus = sequenceStatus.Match(inputLine);
                if (!currentStatus.Success)
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                Regex wordsInSequence = new Regex(wordPattern);
                var validWords = wordsInSequence.Matches(inputLine);
                
                foreach (Match word in validWords)
                {
                    int counter = 0;
                    string currentWord = word.Value;

                    for (int i = 0; i < currentWord.Length; i++)
                    {
                        if (currentWord[i] == symbol)
                        {
                            counter++;
                        }
                        if (counter >= number)
                        {
                            wordsToPrint.Add(currentWord);
                            break;
                        }
                    }

                }
                
                inputLine = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", wordsToPrint));
        }
    }
}
