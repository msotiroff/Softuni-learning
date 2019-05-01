namespace P02.PermutationsWithRepetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static string[] elements;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Permutations(elements, 0);
        }

        private static void Permutations(string[] elements, int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
            }
            else
            {
                var swapped = new HashSet<string>();
                for (int i = index; i < elements.Length; i++)
                {
                    if (!swapped.Contains(elements[i]))
                    {
                        Swap(index, i);
                        Permutations(elements, index + 1);
                        Swap(index, i);
                        swapped.Add(elements[i]);
                    }
                }
            }
        }

        private static void Swap(int first, int second)
        {
            var firstElement = elements[first];
            elements[first] = elements[second];
            elements[second] = firstElement;
        }
    }
}
