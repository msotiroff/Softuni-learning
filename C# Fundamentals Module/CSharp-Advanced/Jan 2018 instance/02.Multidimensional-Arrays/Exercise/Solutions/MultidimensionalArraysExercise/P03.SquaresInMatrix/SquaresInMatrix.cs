namespace P03.SquaresInMatrix
{
    using System;
    using System.Linq;

    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var countOfEqualsSquares = 0;

            var rowsCount = dimensions[0];
            var columnCount = dimensions[1];

            var matrix = new char[rowsCount][];

            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    var areEquals = matrix[row][col] == matrix[row][col + 1] 
                        && matrix[row][col] == matrix[row + 1][col] 
                        && matrix[row][col] == matrix[row + 1][col + 1];

                    if (areEquals)
                    {
                        countOfEqualsSquares++;
                    }
                }
            }

            Console.WriteLine(countOfEqualsSquares);
        }
    }
}
