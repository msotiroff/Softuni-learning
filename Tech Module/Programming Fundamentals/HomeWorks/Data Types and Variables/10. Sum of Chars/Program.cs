using System;

namespace _10.Sum_of_Chars
{
    class SumOfChars
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                int currentCharIndex = Convert.ToInt32(currentChar);
                sum += currentCharIndex;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
