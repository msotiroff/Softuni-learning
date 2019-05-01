namespace P02.NestedLoops
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var nestedLoopsCount = int.Parse(Console.ReadLine());

            int[] vector = new int[nestedLoopsCount];

            PrintAllCombinations(0, vector);
        }

        private static void PrintAllCombinations(int index, int[] vector)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
                return;
            }

            for (int i = 1; i <= vector.Length; i++)
            {
                vector[index] = i;
                PrintAllCombinations(index + 1, vector);
            }
        }
    }
}
