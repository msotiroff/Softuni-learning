namespace P02.SquareWithMaximumSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SquareWithMaximumSum
    {
        public static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowCount = sizes[0];
            var columnCount = sizes[1];

            var matrix = new int[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = currentRow;
            }

            int maxSum = int.MinValue;
            KeyValuePair<int, int> upLeftElement = new KeyValuePair<int, int>(0, 0);

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                var currentRow = matrix[row];

                for (int col = 0; col < currentRow.Length - 1; col++)
                {
                    var currentSum =
                        matrix[row][col]
                        + matrix[row][col + 1]
                        + matrix[row + 1][col]
                        + matrix[row + 1][col + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        upLeftElement = new KeyValuePair<int, int>(row, col);
                    }
                }
            }

            PrintResult(matrix, maxSum, upLeftElement);
        }

        private static void PrintResult(int[][] matrix, int maxSum, KeyValuePair<int, int> upLeftElement)
        {
            var resultRow = upLeftElement.Key;
            var resultColumn = upLeftElement.Value;

            Console.Write(matrix[resultRow][resultColumn] + " ");
            Console.WriteLine(matrix[resultRow][resultColumn + 1]);
            Console.Write(matrix[resultRow + 1][resultColumn] + " ");
            Console.WriteLine(matrix[resultRow + 1][resultColumn + 1]);
            Console.WriteLine(maxSum);
        }
    }
}
