namespace _04.MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            Stack<int> brackets = new Stack<int>();

            for (int i = 0; i < inputLine.Length; i++)
            {
                if (inputLine[i] == '(')
                {
                    brackets.Push(i);
                }
                if (inputLine[i] == ')')
                {
                    int startIndex = brackets.Pop();
                    Console.WriteLine(inputLine.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
