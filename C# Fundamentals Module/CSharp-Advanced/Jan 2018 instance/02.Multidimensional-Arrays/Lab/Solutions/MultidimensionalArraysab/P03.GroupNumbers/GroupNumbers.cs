namespace P03.GroupNumbers
{
    using System;
    using System.Linq;
    using System.Text;

    class GroupNumbers
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[3][];

            matrix[0] = numbers.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            matrix[1] = numbers.Where(n => Math.Abs(n)% 3 == 1).ToArray();
            matrix[2] = numbers.Where(n => Math.Abs(n) % 3 == 2).ToArray();

            Console.WriteLine(DrawMatrix(matrix));
        }

        private static string DrawMatrix(int[][] matrix)
        {
            var result = new StringBuilder();

            foreach (var row in matrix)
            {
                result.AppendLine(string.Join(" ", row));
            }

            return result.ToString().TrimEnd();
        }
    }
}
