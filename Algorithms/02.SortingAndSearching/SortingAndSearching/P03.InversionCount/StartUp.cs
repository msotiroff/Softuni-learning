namespace P03.InversionCount
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var collection = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var result = CountInversions(collection);

            Console.WriteLine(result);
        }

        private static int CountInversions(int[] array)
        {
            var counter = 0;

            for (int current = 0; current < array.Length - 1; current++)
            {
                for (int next = current + 1; next < array.Length; next++)
                {
                    if (array[current] > array[next])
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }
    }
}
