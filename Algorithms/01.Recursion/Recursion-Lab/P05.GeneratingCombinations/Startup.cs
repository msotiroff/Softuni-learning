namespace P05.GeneratingCombinations
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var elements = Console.ReadLine().Split();
            var numberOfElements = int.Parse(Console.ReadLine());
            var vector = new string[numberOfElements];

            GenerateCombinations(elements, vector, 0, 0);
        }

        private static void GenerateCombinations(string[] elements, string[] vector, int index, int border)
        {
            if (index == vector.Length)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = border; i < elements.Length; i++)
                {
                    vector[index] = elements[i];
                    GenerateCombinations(elements, vector, index + 1, i + 1);
                }
            }
        }
    }
}
