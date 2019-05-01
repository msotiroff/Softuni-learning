namespace P03.PeriodicTable
{
    using System;
    using System.Collections.Generic;

    public class PeriodicTable
    {
        public static void Main(string[] args)
        {
            var numberOfCompounds = int.Parse(Console.ReadLine());

            var uniqueElements = new SortedSet<string>();

            for (int i = 0; i < numberOfCompounds; i++)
            {
                var currentCompoundElements = Console.ReadLine().Split();

                for (int j = 0; j < currentCompoundElements.Length; j++)
                {
                    uniqueElements.Add(currentCompoundElements[j]);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueElements));
        }
    }
}
