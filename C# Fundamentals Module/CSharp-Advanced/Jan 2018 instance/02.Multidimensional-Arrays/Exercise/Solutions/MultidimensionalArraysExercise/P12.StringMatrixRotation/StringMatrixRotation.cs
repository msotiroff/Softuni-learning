namespace P12.StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StringMatrixRotation
    {
        static void Main(string[] args)
        {
            // Rotate(90)
            var degree = int.Parse(
                Console.ReadLine()
                .Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                .Last()) % 360;

            var initialMatrix = new List<string>();

            string currentRow;
            while ((currentRow = Console.ReadLine()) != "END")
            {
                initialMatrix.Add(currentRow);
            }

            if (degree.Equals(0))
            {
                initialMatrix.ForEach(r => Console.WriteLine(r));
                Environment.Exit(0);
            }

            var longestString = initialMatrix.Max(x => x.Length);
            
            var matrix = new char[initialMatrix.Count][];

            for (int row = 0; row < initialMatrix.Count; row++)
            {
                matrix[row] = new char[longestString];

                for (int col = 0; col < longestString; col++)
                {
                    if (col < initialMatrix[row].Length)
                    {
                        matrix[row][col] = initialMatrix[row][col];
                    }
                    else
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }

            char[][] finalMatrix = null;

            switch (degree)
            {
                case 90:
                    finalMatrix = Rotate90(matrix, longestString);
                    break;
                case 180:
                    finalMatrix = Rotate180(matrix);
                    break;
                case 270:
                    finalMatrix = Rotate270(matrix, longestString);
                    break;
                default:
                    break;
            }

            PrintResult(finalMatrix);
        }

        private static char[][] Rotate270(char[][] matrix, int longestSequence)
        {
            int matrixLength = matrix.Length;
            int matrixRowsLength = matrix[0].Length;

            var result = new char[longestSequence][];

            for (int row = 0; row < result.Length; row++)
            {
                result[row] = new char[matrix.Length];
            }

            for (int row = 0; row < matrixLength; row++)
            {
                for (int col = 0; col < matrixRowsLength; col++)
                {
                    var currentSymbol = matrix[row][col];

                    var resultRow = longestSequence - 1 - col;
                    var resultCol = row;

                    result[resultRow][resultCol] = currentSymbol;
                }
            }

            return result;
        }

        private static char[][] Rotate90(char[][] matrix, int longestSequence)
        {
            var result = new char[longestSequence][];

            for (int row = 0; row < result.Length; row++)
            {
                result[row] = new char[matrix.Length];
            }

            for (int col = 0; col < longestSequence; col++)
            {
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    var currentSymbol = matrix[row][col];

                    var resultRow = col;
                    var resultCol = matrix.Length - 1 - row;
                    result[resultRow][resultCol] = currentSymbol;
                }
            }

            return result;
        }

        private static char[][] Rotate180(char[][] matrix)
        {
            var result = new char[matrix.Length][];

            for (int row = 0; row < result.Length; row++)
            {
                result[row] = matrix[matrix.Length - row - 1].Reverse().ToArray();
            }

            return result;
        }

        private static void PrintResult(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
