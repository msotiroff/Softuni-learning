namespace P03.MaximumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaximumElement
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<int>();

            int numberOfInputs = int.Parse(Console.ReadLine());

            var maxElement = -1;

            for (int i = 0; i < numberOfInputs; i++)
            {
                var query = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var type = query[0];

                switch (type)
                {
                    case 1:
                        var elementToPush = query[1];

                        stack.Push(query[1]);

                        if (elementToPush > maxElement)
                        {
                            maxElement = elementToPush;
                        }
                        break;
                    case 2:
                        stack.Pop();

                        if (stack.Count > 0)
                        {
                            maxElement = stack.Max();
                        }
                        break;
                    case 3:
                        Console.WriteLine(maxElement);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
