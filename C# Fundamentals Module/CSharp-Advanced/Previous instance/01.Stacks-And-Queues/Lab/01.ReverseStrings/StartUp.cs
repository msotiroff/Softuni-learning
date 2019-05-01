namespace _01.ReverseStrings
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();

            Stack<char> stack = new Stack<char>();

            foreach (var character in input)
            {
                stack.Push(character);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
