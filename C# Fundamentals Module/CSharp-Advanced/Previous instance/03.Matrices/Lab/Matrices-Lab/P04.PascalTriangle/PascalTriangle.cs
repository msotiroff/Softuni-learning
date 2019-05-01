namespace P04.PascalTriangle
{
    using System;

    public class PascalTriangle
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            var paskalTriangle = new long[rows][];
            paskalTriangle[0] = new long[1];
            paskalTriangle[0][0] = 1;

            for (int row = 1; row < rows; row++)
            {
                paskalTriangle[row] = new long[row + 1];

                paskalTriangle[row][0] = 1;

                for (int col = 1; col <= row; col++)
                {
                    long upperLeftElement = 0;
                    long upperRightElement = 0;

                    if (IsInBoundsOfMatrix(paskalTriangle, row - 1, col - 1))
                    {
                        upperLeftElement = paskalTriangle[row - 1][col - 1];
                    }
                    if (IsInBoundsOfMatrix(paskalTriangle, row - 1, col))
                    {
                        upperRightElement = paskalTriangle[row - 1][col];
                    }

                    var currentElement = upperLeftElement + upperRightElement;

                    paskalTriangle[row][col] = currentElement;
                }
            }

            PrintTriangle(paskalTriangle);
        }

        private static void PrintTriangle(long[][] paskalTriangle)
        {
            foreach (var row in paskalTriangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static bool IsInBoundsOfMatrix(long[][] matrix, int row, int column)
        {
            bool isInRange = true;

            if (row < 0 || row > matrix.Length - 1 || column < 0 || column > matrix[row].Length - 1)
            {
                isInRange = false;
            }

            return isInRange;
        }
    }
}
