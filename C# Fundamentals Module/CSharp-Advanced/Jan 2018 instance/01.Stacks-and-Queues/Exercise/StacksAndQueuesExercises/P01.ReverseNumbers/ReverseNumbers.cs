namespace P01.ReverseNumbers
{
    using System;
    using System.Linq;

    class ReverseNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToStack();

            while (numbers.Count > 0)
            {
                Console.Write($"{numbers.Pop()} ");
            }
            Console.WriteLine();
        }
    }
}
