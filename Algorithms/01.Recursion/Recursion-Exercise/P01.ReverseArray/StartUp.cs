namespace P01.ReverseArray
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split();

            ReverseRecursively(arr, 0, arr.Length - 1);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void ReverseRecursively(string[] arr, int firstIndex, int lastIndex)
        {
            if (firstIndex < lastIndex)
            {
                var leftElement = arr[firstIndex];
                var rightElement = arr[lastIndex];
                arr[lastIndex] = leftElement;
                arr[firstIndex] = rightElement;
                ReverseRecursively(arr, firstIndex + 1, lastIndex - 1);
            }
        }
    }
}
