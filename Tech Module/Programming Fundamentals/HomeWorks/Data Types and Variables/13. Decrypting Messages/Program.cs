using System;

namespace _13.Decrypting_Messages
{
    class DecryptingMessages
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfInputs = int.Parse(Console.ReadLine());

            string result = string.Empty;

            for (int i = 0; i < numberOfInputs; i++)
            {
                char currentLetter = char.Parse(Console.ReadLine());
                int currentIndex = Convert.ToInt32(currentLetter);
                int askedIndex = currentIndex + key;
                char neededLetter = Convert.ToChar(askedIndex);
                result += neededLetter;
            }

            Console.WriteLine(result);
        }
    }
}
