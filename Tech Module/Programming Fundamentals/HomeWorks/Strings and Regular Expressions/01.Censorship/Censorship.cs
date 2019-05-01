using System;
using System.Text.RegularExpressions;

namespace _01.Censorship
{
    class Censorship
    {
        static void Main(string[] args)
        {
            string wordToReplace = Console.ReadLine();
            string text = Console.ReadLine();

            text = Regex.Replace(text, wordToReplace, new string('*', wordToReplace.Length));

            Console.WriteLine(text);
        }
    }
}
