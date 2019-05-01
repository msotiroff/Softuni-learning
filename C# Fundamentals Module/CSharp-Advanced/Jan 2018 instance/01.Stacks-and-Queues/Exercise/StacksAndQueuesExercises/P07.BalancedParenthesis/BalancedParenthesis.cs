namespace P07.BalancedParenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BalancedParenthesis
    {
        static void Main(string[] args)
        {
            var result = string.Empty;

            var input = Console.ReadLine().ToCharArray();
            
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentBracket = input[i];

                if (currentBracket.Equals(')') && stack.Any())
                {
                    if (stack.Peek().Equals('('))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        result = "NO";
                        break;
                    }
                }
                else if (currentBracket.Equals(']') && stack.Any())
                {
                    if (stack.Peek().Equals('['))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        result = "NO";
                        break;
                    }
                }
                else if (currentBracket.Equals('}') && stack.Any())
                {
                    if (stack.Peek().Equals('{'))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        result = "NO";
                        break;
                    }
                }
                else
                {
                    stack.Push(currentBracket);
                }
            }

            if (result != string.Empty)
            {
                Console.WriteLine(result);
            }
            else
            {
                if (stack.Any())
                {
                    result = "NO";
                }
                else
                {
                    result = "YES";
                }

                Console.WriteLine(result);
            }
        }
    }
}
