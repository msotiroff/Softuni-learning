namespace P03.DecimalToBinaryConverter
{
    using System;
    using System.Collections.Generic;

    class DecimalToBinaryConverter
    {
        static void Main(string[] args)
        {
            var number = int.Parse(Console.ReadLine());

            if (number.Equals(0))
            {
                Console.WriteLine(number);
                Environment.Exit(0);
            }

            var result = new Stack<int>();

            while (number > 0)
            {
                var reminder = number % 2;
                result.Push(reminder);
                number /= 2;
            }

            while (result.Count > 0)
            {
                Console.Write(result.Pop());
            }

            Console.WriteLine();
        }
    }
}
