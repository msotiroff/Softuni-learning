using System;

namespace _10.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char currentLetter = input[i];

                int index = Convert.ToInt32(currentLetter) - 97;

                Console.WriteLine($"{currentLetter} -> {index}");
            }
        }
    }
}
