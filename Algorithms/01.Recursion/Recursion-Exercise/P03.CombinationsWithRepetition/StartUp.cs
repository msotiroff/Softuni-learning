namespace P03.CombinationsWithRepetition
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var set = Enumerable.Range(1, n).ToArray();

            var vector = new int[k];

            GenerateCombination(set, vector, 0, 0);
        }

        private static void GenerateCombination(int[] set, int[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = border; i < set.Length; i++)
            {
                vector[index] = set[i];
                GenerateCombination(set, vector, index + 1, i);
            }
        }
    }
}
