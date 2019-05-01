﻿namespace SetCover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SetCover
    {
        public static void Main(string[] args)
        {
            var universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
            var sets = new[]
            {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

            var selectedSets = ChooseSets(sets.ToList(), universe.ToList());
            Console.WriteLine($"Sets to take ({selectedSets.Count}):");
            foreach (var set in selectedSets)
            {
                Console.WriteLine($"{{ {string.Join(", ", set)} }}");
            }
        }

        public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            var universeSet = new List<int>(universe);
            var availableSets = new HashSet<int[]>(sets);
            var result = new List<int[]>();

            while (universeSet.Any() && availableSets.Any())
            {
                var currentSet = availableSets
                    .OrderByDescending(s => s.Count(x => universeSet.Contains(x)))
                    .First();

                result.Add(currentSet);

                availableSets.Remove(currentSet);

                universeSet.RemoveAll(x => currentSet.Contains(x));
            }

            return result;
        }
    }
}
