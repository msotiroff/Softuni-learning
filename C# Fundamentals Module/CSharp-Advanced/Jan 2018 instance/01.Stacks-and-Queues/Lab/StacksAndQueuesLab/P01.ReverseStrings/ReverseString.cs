namespace P01.ReverseStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class ReverseString
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine().ToCharArray().ToList();

            var stack = new Stack<char>();

            inputLine.ForEach(e => stack.Push(e));

            var result = new StringBuilder();

            while (stack.Count > 0)
            {
                result.Append(stack.Pop());
            }

            Console.WriteLine(result);
        }
    }
}
