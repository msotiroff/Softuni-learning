using System;
using System.Linq;

namespace _6.Capitalize_Words
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();


            while (inputLine != "end")
            {
                string[] inputWords = inputLine
                    .Split(new[] {' ', '.', ',', '!', '?', '-', ':', ';', '"'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < inputWords.Length; i++)
                {
                    inputWords[i] =  inputWords[i].First().ToString().ToUpper() + inputWords[i].Substring(1).ToLower();
                }
                Console.WriteLine(string.Join(", ", inputWords));

                inputLine = Console.ReadLine();
            }


        }
    }
}
