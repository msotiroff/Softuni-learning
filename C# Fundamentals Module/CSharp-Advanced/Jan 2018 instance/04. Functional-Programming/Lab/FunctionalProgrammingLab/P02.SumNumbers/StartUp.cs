namespace P02.SumNumbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Action<int[]> printCount = s => Console.WriteLine(s.Length);

            Action<int[]> printSum = s => Console.WriteLine(s.Sum());

            Func<string, int[]> parseCollection = str => str.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var numbers = parseCollection(Console.ReadLine());

            printCount(numbers);
            printSum(numbers);
        }
    }
}
