namespace P04.MaximalSum
{
    using System;
    using System.Linq;
    using System.Text;

    class MaximalSum
    {
        private static int[][] matrix;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowsCount = dimensions[0];
            var columnsCount = dimensions[1];

            matrix = new int[rowsCount][];

            var maxSum = int.MinValue;
            var upperLeftRow = 0;
            var upperLeftCol = 0;

            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            }

            for (int row = 0; row < rowsCount - 2; row++)
            {
                for (int col = 0; col < columnsCount - 2; col++)
                {
                    var currentSum = GetSubmatrixSum(row, col);

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        upperLeftRow = row;
                        upperLeftCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine(DrawSubmatrix(upperLeftRow, upperLeftCol));
        }

        private static string DrawSubmatrix(int upperLeftRow, int upperLeftCol)
        {
            var builder = new StringBuilder();

            var firstRow = string.Join(" ", matrix[upperLeftRow].Skip(upperLeftCol).Take(3));
            var secondRow = string.Join(" ", matrix[upperLeftRow + 1].Skip(upperLeftCol).Take(3));
            var thirdRow = string.Join(" ", matrix[upperLeftRow + 2].Skip(upperLeftCol).Take(3));

            builder.AppendLine(firstRow);
            builder.AppendLine(secondRow);
            builder.Append(thirdRow);

            var result = builder.ToString();

            return result;
        }

        private static int GetSubmatrixSum(int row, int col)
        {
            var totalSum = matrix[row].Skip(col).Take(3).Sum()
                + matrix[row + 1].Skip(col).Take(3).Sum()
                + matrix[row + 2].Skip(col).Take(3).Sum();

            return totalSum;
        }
    }
}
