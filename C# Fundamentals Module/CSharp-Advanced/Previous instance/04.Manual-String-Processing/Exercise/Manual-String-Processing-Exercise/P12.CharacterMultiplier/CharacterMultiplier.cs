namespace P12.CharacterMultiplier
{
    using System;

    public class CharacterMultiplier
    {
        public static void Main(string[] args)
        {
            var words = Console.ReadLine().Split();

            var firstWord = words[0];
            var secondWord = words[1];

            var shortestWordLength = Math.Min(firstWord.Length, secondWord.Length);

            var sum = 0;

            for (int i = 0; i < shortestWordLength; i++)
            {
                var currentProduct = (int)firstWord[i] * (int)secondWord[i];

                sum += currentProduct;
            }

            if (firstWord.Length > secondWord.Length)
            {
                for (int i = shortestWordLength; i < firstWord.Length; i++)
                {
                    sum += (int)firstWord[i];
                }
            }
            else if (firstWord.Length < secondWord.Length)
            {
                for (int i = shortestWordLength; i < secondWord.Length; i++)
                {
                    sum += (int)secondWord[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
