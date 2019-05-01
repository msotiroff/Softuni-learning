using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Randomize_Words
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            Random randomWords = new Random();
           

            for (int i = 0; i < input.Length; i++)
            {
                int randomIndex = randomWords.Next(0, input.Length);
                string copyOfWordAtI = input[i];
                input[i] = input[randomIndex];
                input[randomIndex] = copyOfWordAtI;
            }

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
