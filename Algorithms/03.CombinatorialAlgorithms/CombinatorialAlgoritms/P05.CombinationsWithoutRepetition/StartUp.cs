namespace P05.CombinationsWithoutRepetition
{
    using System;

    class StartUp
    {
        private static string[] elements;
        private static int k;
        private static string[] vector;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split();
            k = int.Parse(Console.ReadLine());
            vector = new string[k];

            GenerateVariation(0, 0);
        }

        private static void GenerateVariation(int index, int border)
        {
            if (index >= k)
            {
                Console.WriteLine(string.Join(" ", vector));
            }
            else
                for (int i = border; i < elements.Length; i++)
                {
                    vector[index] = elements[i];
                    GenerateVariation(index + 1, i + 1);
                }

        }
    }
}
