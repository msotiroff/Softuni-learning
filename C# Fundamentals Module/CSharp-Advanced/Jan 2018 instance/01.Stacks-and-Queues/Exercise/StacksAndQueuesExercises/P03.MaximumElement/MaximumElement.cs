namespace P03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MaximumElement
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            var maxElements = new Stack<int>();
            maxElements.Push(int.MinValue);

            for (int i = 0; i < numberOfLines; i++)
            {
                var command = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                switch (command[0])
                {
                    case 1:
                        stack.Push(command[1]);
                        if (maxElements.Peek() <= command[1])
                        {
                            maxElements.Push(command[1]);
                        }
                        break;
                    case 2:
                        var currentNumber = stack.Peek();
                        if (maxElements.Any())
                        {
                            if (currentNumber == maxElements.Peek())
                            {
                                maxElements.Pop();
                            }
                        }
                        if (stack.Any())
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        Console.WriteLine(maxElements.Peek());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
