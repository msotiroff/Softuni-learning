namespace P04.VariationsWithRepetition
{
    using System;

    class StartUp
    {
        private static string[] elements;
        private static int k;
        private static string[] vector;
        private static bool[] used;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());
            vector = new string[k];
            used = new bool[elements.Length];

            GenerateVariation(0);
        }

        private static void GenerateVariation(int index)
        {
            if (index == k)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    vector[index] = elements[i];
                    GenerateVariation(index + 1);
                }
            }
        }
    }
}
