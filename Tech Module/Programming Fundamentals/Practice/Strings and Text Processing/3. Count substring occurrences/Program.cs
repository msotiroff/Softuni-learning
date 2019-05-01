using System;

namespace _3.Count_substring_occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine().ToLower();

            string bannedWord = Console.ReadLine().ToLower();
            int counter = 0;

            int index = inputText.IndexOf(bannedWord);
            while (index != -1)
            {
                counter++;
                index = inputText.IndexOf(bannedWord, index + 1);
            }

            Console.WriteLine(counter);
        }
    }
}
