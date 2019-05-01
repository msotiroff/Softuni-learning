namespace P13.TriFunction
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var minSum = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isLarger = (name, sum) => name.Sum(c => Convert.ToInt32(c)) >= sum;

            Func<string[], Func<string, int, bool>, string> findFirstOccurence
                = (collection, func) => collection.FirstOrDefault(n => isLarger(n, minSum));

            var result = findFirstOccurence(names, isLarger);

            Console.WriteLine(result);
        }
    }
}
