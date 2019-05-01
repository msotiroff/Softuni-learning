namespace P04.MaximalSum
{
    using System;
    using System.Linq;
    using System.Text;

    public class MaximalSum
    {
        public static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSizes[0];
            var columns = matrixSizes[1];

            var matrix = new long[rows][];
            var maxSubmatrixSum = long.MinValue;
            var maxSubmatrix = new long[3][];

            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                matrix[row] = currentRow;
            }

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int column = 0; column < matrix[row].Length - 2; column++)
                {
                    long[][] currentSubmatrix = GetSubmatrix(matrix, row, column);

                    long currentSum = GetMatrixSum(currentSubmatrix);

                    if (currentSum > maxSubmatrixSum)
                    {
                        maxSubmatrixSum = currentSum;

                        maxSubmatrix = currentSubmatrix;
                    }
                }
            }

            PrintResult(maxSubmatrixSum, maxSubmatrix);
        }

        private static void PrintResult(long sum, long[][] matrix)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Sum = {sum}");
            foreach (var row in matrix)
            {
                builder.AppendLine(string.Join(" ", row));
            }

            var result = builder.ToString().TrimEnd();

            Console.WriteLine(result);
        }

        private static long GetMatrixSum(long[][] matrix)
        {
            long sum = 0;

            foreach (var row in matrix)
            {
                sum += row.Sum();
            }

            return sum;
        }

        private static long[][] GetSubmatrix(long[][] matrix, int row, int column)
        {
            var subMatrix = new long[3][];

            subMatrix[0] = new long[] 
            {
                matrix[row][column],
                matrix[row][column + 1],
                matrix[row][column + 2]
            };

            subMatrix[1] = new long[]
            {
                matrix[row + 1][column],
                matrix[row + 1][column + 1],
                matrix[row + 1][column + 2]
            };

            subMatrix[2] = new long[] 
            {

                matrix[row + 2][column],
                matrix[row + 2][column + 1],
                matrix[row + 2][column + 2]
            };

            return subMatrix;
        }
    }
}
