namespace P07.BalancedParenthesis
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            
            var stack = new Stack<char>();

            var isSequenceBalanced = true;
            var validBrackets = new char[] { '{', '[', '(' };

            for (int i = 0; i < input.Length; i++)
            {
                var currentBracket = input[i];

                if (validBrackets.Contains(currentBracket))
                {
                    stack.Push(currentBracket);
                }
                else
                {
                    if (!stack.Any())
                    {
                        isSequenceBalanced = false;
                        break;
                    }
                    switch (currentBracket)
                    {
                        case ')':
                            if (stack.Pop() != '(')
                            {
                                isSequenceBalanced = false;
                            }
                            break;
                        case ']':
                            if (stack.Pop() != '[')
                            {
                                isSequenceBalanced = false;
                            }
                            break;
                        case '}':
                            if (stack.Pop() != '{')
                            {
                                isSequenceBalanced = false;
                            }
                            break;
                        default:
                            break;
                    }
                }

                if (!isSequenceBalanced)
                {
                    break;
                }
            }

            Console.WriteLine(isSequenceBalanced ? "YES" : "NO");
        }
    }
}
