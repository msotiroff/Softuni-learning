namespace P03.SquaresInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SquaresInMatrix
    {
        public static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSizes[0];
            var columns = matrixSizes[1];

            var matrix = new char[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                matrix[row] = currentRow;
            }

            int counter = 0;

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int column = 0; column < matrix[row].Length - 1; column++)
                {
                    bool areElementsEqual = AreElementsEqual(matrix, row, column);

                    if (areElementsEqual)
                    {
                        counter++;
                    }
                }
            }
            
            Console.WriteLine(counter);
        }

        private static bool AreElementsEqual(char[][] matrix, int row, int column)
        {
            var firstElement = matrix[row][column];
            var secondElement = matrix[row][column + 1];
            var thirdElement = matrix[row + 1][column];
            var forthElement = matrix[row + 1][column + 1];

            var result = firstElement == secondElement 
                && secondElement == thirdElement 
                && thirdElement == forthElement;

            return result;
        }
    }
}
