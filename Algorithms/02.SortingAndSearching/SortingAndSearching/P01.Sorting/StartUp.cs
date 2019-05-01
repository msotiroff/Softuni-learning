namespace P01.Sorting
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

            MergeSort<int>.Sort(collection, 0, collection.Length - 1);

            Console.WriteLine(string.Join(" ", collection));
        }
    }

    public class MergeSort<T>
        where T : IComparable<T>
    {
        private static T[] helperArr;

        public static void Sort(T[] arr, int low, int high)
        {
            helperArr = new T[arr.Length];

            if (low >= high)
            {
                return;
            }

            var middle = (low + high) / 2;

            Sort(arr, low, middle);
            Sort(arr, middle + 1, high);
            Merge(arr, low, middle, high);
        }

        private static void Merge(T[] arr, int low, int middle, int high)
        {
            if (arr[middle].CompareTo(arr[middle + 1]) <= 0)
            {
                return;
            }

            for (int index = low; index <= high; index++)
            {
                helperArr[index] = arr[index];
            }

            int leftIndex = low;
            int rightIndex = middle + 1;

            for (int index = low; index <= high; index++)
            {
                if (leftIndex > middle)
                {
                    arr[index] = helperArr[rightIndex++];
                }
                else if (rightIndex > high)
                {
                    arr[index] = helperArr[leftIndex++];
                }
                else if (helperArr[leftIndex].CompareTo(helperArr[rightIndex]) <= 0)
                {
                    arr[index] = helperArr[leftIndex++];
                }
                else
                {
                    arr[index] = helperArr[rightIndex++];
                }
            }
        }
    }
}
