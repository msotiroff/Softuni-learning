using System;
using System.Linq;

namespace _4.Text_filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string inputText = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                string currentBan = bannedWords[i];

                inputText = inputText.Replace(currentBan, new string('*', currentBan.Length));
            }

            Console.WriteLine(inputText);
        }
    }
}
