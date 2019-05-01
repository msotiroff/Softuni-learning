using System;
using System.Linq;

namespace _04.CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();

            var firstWord = input[0];
            var secondWord = input[1];

            int sum = MultiplyCharacters(firstWord, secondWord);
            
            Console.WriteLine(sum);
        }

        public static int MultiplyCharacters(string firstWord, string secondWord)
        {
            int summed = 0;

            if (firstWord.Length >= secondWord.Length)
            {
                for (int i = 0; i < secondWord.Length; i++)
                {
                    summed += Convert.ToInt16(firstWord[i]) * Convert.ToInt16(secondWord[i]);
                }
                for (int i = secondWord.Length; i < firstWord.Length; i++)
                {
                    summed += Convert.ToInt16(firstWord[i]);
                }
            }
            else
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    summed += Convert.ToInt16(secondWord[i]) * Convert.ToInt16(firstWord[i]);
                }
                for (int i = firstWord.Length; i < secondWord.Length; i++)
                {
                    summed += Convert.ToInt16(secondWord[i]);
                }
            }

            return summed;
        }
    }
}
