namespace _02.SimpleCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .ToArray();

            Stack<string> result = new Stack<string>(input.Reverse());

            while (result.Count > 1)
            {
                int firstNumber = int.Parse(result.Pop());
                string operand = result.Pop();
                int secondNumber = int.Parse(result.Pop());

                if (operand == "+")
                {
                    result.Push((firstNumber + secondNumber).ToString());
                }
                else if (operand == "-")
                {
                    result.Push((firstNumber - secondNumber).ToString());
                }
            }

            Console.WriteLine(result.Pop());
        }
    }
}
