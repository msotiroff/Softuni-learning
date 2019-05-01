namespace P02.SetsOfElements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetsOfElements
    {
        public static void Main(string[] args)
        {
            var firstSet = new HashSet<string>();

            var secondSet = new HashSet<string>();

            var countOfSets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            SeedSets(firstSet, secondSet, countOfSets);

            var result = firstSet.Intersect(secondSet);

            Console.WriteLine(string.Join(" ", result));
        }

        private static void SeedSets(HashSet<string> firstSet, HashSet<string> secondSet, int[] countOfSets)
        {
            for (int i = 0; i < countOfSets[0]; i++)
            {
                var currentElement = Console.ReadLine();

                firstSet.Add(currentElement);
            }

            for (int i = 0; i < countOfSets[1]; i++)
            {
                var currentElement = Console.ReadLine();

                secondSet.Add(currentElement);
            }
        }
    }
}
