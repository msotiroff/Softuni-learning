namespace P02.Searching
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
                .OrderBy(x => x)
                .ToArray();

            var key = int.Parse(Console.ReadLine());

            var result = BinarySearch.IndexOf(collection, key);

            Console.WriteLine(result);
        }

        public class BinarySearch
        {
            public static int IndexOf(int[] array, int key)
            {
                int leftIndex = 0;
                int rightIndex = array.Length - 1;

                while (leftIndex <= rightIndex)
                {
                    int middleIndex = (leftIndex + rightIndex) / 2;

                    if (key < array[middleIndex])
                    {
                        rightIndex = middleIndex - 1;
                    }
                    else if (key > array[middleIndex])
                    {
                        leftIndex = middleIndex + 1;
                    }
                    else
                    {
                        return middleIndex;
                    }
                }

                return -1;
            }
        }
    }
}
