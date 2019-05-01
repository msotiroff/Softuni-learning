namespace P05.AppliedArithmetics
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> add = x => x.Select(n => n + 1).ToArray();
            Func<int[], int[]> subtract = x => x.Select(n => n - 1).ToArray();
            Func<int[], int[]> multiply = x => x.Select(n => n * 2).ToArray();
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
