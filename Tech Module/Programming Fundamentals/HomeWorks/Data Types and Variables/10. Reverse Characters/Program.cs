using System;

namespace _10.Reverse_Characters
{
    class ReverseCharacters
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());
            string result = $"{third}{second}{first}";

            Console.WriteLine(result);
        }
    }
}
