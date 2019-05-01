using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _08.UseYourChainsBuddy
{
    class UseYourChainsBuddy
    {
        static void Main(string[] args)
        {
            string htmlDoc = Console.ReadLine();
            string manual = string.Empty;
            var firstPartAlphabet = "abcdefghijklm";
            var secondPartAlphabet = "nopqrstuvwxyz";

            Regex getTags = new Regex(@"<p>(.*?)<\/p>");

            var matchedTags = getTags.Matches(htmlDoc);

            foreach (Match tag in matchedTags)
            {
                string tagContent = tag.Groups[1].Value.ToString();
                tagContent = Regex.Replace(tagContent, @"[^a-z0-9]+", " ");

                for (int i = 0; i < tagContent.Length; i++)
                {
                    char currentLetter = tagContent[i];
                    if (char.IsLetter(currentLetter))
                    {
                        if (firstPartAlphabet.Contains(currentLetter))
                        {
                            manual += secondPartAlphabet[firstPartAlphabet.IndexOf(currentLetter)];
                        }
                        else
                        {
                            manual += firstPartAlphabet[secondPartAlphabet.IndexOf(currentLetter)];
                        }
                    }
                    else
                    {
                        manual += currentLetter;
                    }
                }
            }

            Console.WriteLine(manual);
        }
    }
}
