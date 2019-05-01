namespace P12.StringMatrixRotation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StringMatrixRotation
    {
        public static void Main(string[] args)
        {
            var degreesToRotate = Console.ReadLine()
                .Split(new char[] { '(', ')'}, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .Take(1)
                .Select(int.Parse)
                .First() % 360;

            var jaggedArray = new List<List<char>>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "END")
            {
                var currentRow = inputLine.ToCharArray();
                jaggedArray.Add(new List<char>(currentRow));
            }

            var longestRowCount = jaggedArray.Max(r => r.Count);

            var matrix = new char[jaggedArray.Count][];

            for (int row = 0; row < jaggedArray.Count; row++)
            {
                matrix[row] = new char[longestRowCount];

                for (int col = 0; col < longestRowCount; col++)
                {
                    if (col < jaggedArray[row].Count)
                    {
                        matrix[row][col] = jaggedArray[row][col];
                    }
                    else
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }

            char[][] finalMatrix;

            switch (degreesToRotate)
            {
                case 90:
                    finalMatrix = RotateQuarter(matrix);
                    PrintMatrix(finalMatrix);
                    break;
                case 180:
                    finalMatrix = RotateHalf(matrix);
                    PrintMatrix(finalMatrix);
                    break;
                case 270:
                    finalMatrix = RotateThreeQuarters(matrix);
                    PrintMatrix(finalMatrix);
                    break;
                case 0:
                    finalMatrix = matrix;
                    PrintMatrix(finalMatrix);
                    break;
                default:
                    break;
            }
        }

        private static char[][] RotateQuarter(char[][] matrix)
        {
            var orgMatrixRowCount = matrix.Length;
            var orgMatrixColumnCount = matrix[0].Length;

            var newMatrix = new char[orgMatrixColumnCount][];

            for (int row = 0; row < orgMatrixColumnCount; row++)
            {
                newMatrix[row] = new char[orgMatrixRowCount];

                for (int column = 0; column < orgMatrixRowCount; column++)
                {
                    var newValue = matrix[orgMatrixRowCount - 1 - column][row];
                    newMatrix[row][column] = newValue;
                }
            }

            return newMatrix;
        }

        private static char[][] RotateThreeQuarters(char[][] matrix)
        {
            var orgMatrixRowCount = matrix.Length;
            var orgMatrixColumnCount = matrix[0].Length;

            var newMatrix = new char[orgMatrixColumnCount][];

            for (int column = orgMatrixColumnCount - 1; column >= 0; column--)
            {
                newMatrix[orgMatrixColumnCount - 1 - column] = new char[orgMatrixRowCount];

                for (int row = 0; row < orgMatrixRowCount; row++)
                {
                    newMatrix[orgMatrixColumnCount - 1 - column][row] = matrix[row][column];
                }
            }

            return newMatrix;
        }

        private static char[][] RotateHalf(char[][] matrix)
        {
            var matrixRowCount = matrix.Length;
            var newMatrix = new char[matrixRowCount][];

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                var newMatrixCurrentRow = matrix.Length - 1 - row;
                newMatrix[newMatrixCurrentRow] = matrix[row].Reverse().ToArray();
            }

            return newMatrix;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
