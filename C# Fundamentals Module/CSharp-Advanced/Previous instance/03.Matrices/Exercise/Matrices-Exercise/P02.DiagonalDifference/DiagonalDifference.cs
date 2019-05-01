namespace P02.DiagonalDifference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            var matrix = new long[matrixSize][];

            for (int row = 0; row < matrixSize; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                matrix[row] = currentRow;
            }

            long leftDiagonal = 0;

            for (int index = 0; index < matrix.Length; index++)
            {
                var currentElement = matrix[index][index];
                leftDiagonal += currentElement;
            }

            long rightDiagonal = 0;

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                var columnIndex = matrix.Length - 1 - rowIndex;

                var currentElement = matrix[rowIndex][columnIndex];
                rightDiagonal += currentElement;
            }

            var result = Math.Abs(leftDiagonal - rightDiagonal);

            Console.WriteLine(result);
        }
    }
}
