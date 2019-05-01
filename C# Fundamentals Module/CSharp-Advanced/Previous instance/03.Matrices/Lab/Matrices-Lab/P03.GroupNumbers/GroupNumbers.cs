namespace P03.GroupNumbers
{
    using System;
    using System.Linq;

    public class GroupNumbers
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[3][];

            matrix[0] = numbers.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            matrix[1] = numbers.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            matrix[2] = numbers.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
