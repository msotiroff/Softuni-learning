namespace P03.CustomMinFunction
{
    using System;
    using System.Linq;

    public class CustomMinFunction
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> customMin = a => a.Min();

            Console.WriteLine(customMin(numbers));
        }
    }
}
