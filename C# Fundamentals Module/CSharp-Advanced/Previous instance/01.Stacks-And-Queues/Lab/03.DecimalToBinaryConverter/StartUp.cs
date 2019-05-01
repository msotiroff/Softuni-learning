namespace _03.DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            int inputNumber = int.Parse(Console.ReadLine());

            Stack<int> result = new Stack<int>();

            if (inputNumber == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                while (inputNumber > 0)
                {
                    result.Push(inputNumber % 2);
                    inputNumber /= 2;
                }

                while (result.Count > 0)
                {
                    Console.Write(result.Pop());
                }

                Console.WriteLine();
            }
        }
    }
}
