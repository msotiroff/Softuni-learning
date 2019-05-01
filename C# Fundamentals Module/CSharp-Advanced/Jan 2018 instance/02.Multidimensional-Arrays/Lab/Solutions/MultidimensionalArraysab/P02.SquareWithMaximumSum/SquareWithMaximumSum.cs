namespace P02.SquareWithMaximumSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SquareWithMaximumSum
    {
        private static int[,] matrix;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowsCount = dimensions[0];
            var columnsCount = dimensions[1];

            matrix = new int[rowsCount, columnsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                var currentRow = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < columnsCount; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            var maxSum = int.MinValue;
            var maxSubmatrixRow = 0;
            var maxSubmatrixCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    var currentSum = GetSubMatrixSum(row, col);

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSubmatrixRow = row;
                        maxSubmatrixCol = col;
                    }
                }
            }

            Console.WriteLine(GetSubMatrix(maxSubmatrixRow, maxSubmatrixCol));
            Console.WriteLine(maxSum);
        }

        private static string GetSubMatrix(int maxSubmatrixRow, int maxSubmatrixCol)
        {
            return $"{matrix[maxSubmatrixRow, maxSubmatrixCol]} {matrix[maxSubmatrixRow, maxSubmatrixCol + 1]}" +
                $"{Environment.NewLine}{matrix[maxSubmatrixRow + 1, maxSubmatrixCol]} {matrix[maxSubmatrixRow + 1, maxSubmatrixCol + 1]}";

        }

        private static int GetSubMatrixSum(int row, int col)
        {
            return matrix[row, col]
                + matrix[row, col + 1]
                + matrix[row + 1, col]
                + matrix[row + 1, col + 1];
        }
    }
}
