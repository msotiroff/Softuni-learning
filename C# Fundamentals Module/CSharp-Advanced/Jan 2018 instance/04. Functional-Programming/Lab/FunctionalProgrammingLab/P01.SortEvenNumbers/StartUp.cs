namespace P01.SortEvenNumbers
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Action<int[]> printEvenOrdered = 
                s => Console.WriteLine(
                        string.Join(", ", s.Where(n => n % 2 == 0).OrderBy(n => n)));
             
            Func<string, int[]> parser = 
                s => s
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var sequence = parser(Console.ReadLine());

            printEvenOrdered(sequence);
        }
    }
}
