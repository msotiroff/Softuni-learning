namespace P04.MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine();

            var result = new List<string>();

            var stack = new Stack<int>();

            for (int i = 0; i < inputLine.Length; i++)
            {
                var currentSymbol = inputLine[i];

                if (currentSymbol == '(')
                {
                    stack.Push(i);
                }
                else if (currentSymbol == ')')
                {
                    var startIndex = stack.Pop();

                    result.Add(inputLine.Substring(startIndex, i - startIndex + 1));
                }
            }

            result.ForEach(x => Console.WriteLine(x));
        }
    }
}
