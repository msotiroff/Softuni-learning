namespace P07.PredicateForNames
{
    using System;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main(string[] args)
        {
            var maxNameLength = int.Parse(Console.ReadLine());

            Predicate<string> nameFilter = s => s.Length <= maxNameLength;

            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(n => nameFilter(n));

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
