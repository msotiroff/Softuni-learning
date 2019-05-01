namespace P01.PermutationsWoRepetition
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static char[] elements;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();

            Permutations(elements, 0);
        }

        private static void Permutations(char[] numbers, int index)
        {
            if (index == numbers.Length)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
            else
            {
                for (int i = index; i < numbers.Length; i++)
                {
                    Swap(index, i);
                    Permutations(numbers, index + 1);
                    Swap(index, i);
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
