using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace _3.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read the key words from an existing file(words.txt):
            string[] keyWords = File.ReadAllText("words.txt")
                .ToLower()
                .Split()
                .ToArray();

            // Read the text from an existing file(text.txt):
            string[] text = File.ReadAllText("text.txt")
                .ToLower()
                .Split(new[] { ' ', '.', ',', '?', '!', '-' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            // Create a collection, and count how many times the text contains some of key words:
            Dictionary<string, int> repeatedWords = new Dictionary<string, int>();

            for (int i = 0; i < text.Length; i++)
            {

                for (int j = 0; j < keyWords.Length; j++)
                {
                    if (text[i] == keyWords[j])
                    {
                        if (!repeatedWords.ContainsKey(text[i]))
                        {
                            repeatedWords[text[i]] = 1;
                        }
                        else
                        {
                            repeatedWords[text[i]]++;
                        }
                    }
                }
            }

            // Make a new collection of key words found in the text, sorted by their count value in descending order:
            List<string> outputLines = new List<string>();

            foreach (var repeatedWord in repeatedWords.OrderByDescending(w => w.Value))
            {
                outputLines.Add($"{repeatedWord.Key} - {repeatedWord.Value}");
            }

            // Create new .txt file and append all contained strings from "outputLines" 
            //to "Output.txt", separated by new line:
            File.AppendAllLines("Output.txt", outputLines);

        }
    }
}
