namespace P01.SumMatrixElements
{
    using System;
    using System.Linq;

    class SumMatrixElements
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var columns = dimensions[1];

            var matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < currentRow.Length; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }

            var matrixSum = SumElements(matrix);

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(matrixSum);
        }

        private static int SumElements(int[,] matrix)
        {
            var sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }

            return sum;
        }
    }
}
