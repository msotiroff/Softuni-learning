namespace P02.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SimpleCalculator
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine().Split().Reverse().ToList();

            var stack = new Stack<string>();

            inputLine.ForEach(e => stack.Push(e));

            while (stack.Count > 1)
            {
                var firstNumber = long.Parse(stack.Pop());
                var operand = stack.Pop();
                var secondNumber = long.Parse(stack.Pop());

                var result = 0L;

                switch (operand)
                {
                    case "+":
                        result = firstNumber + secondNumber;
                        break;
                    case "-":
                        result = firstNumber - secondNumber;
                        break;
                    default:
                        break;
                }

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
