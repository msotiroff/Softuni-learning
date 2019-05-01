namespace P01.MatrixOfPalindromes
{
    using System;
    using System.Linq;

    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var columns = dimensions[1];

            var matrix = new string[rows, columns];
            
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var currentPalindrome = $"{(char)('a' + row)}{(char)('a' + row + col)}{(char)('a' + row)}";

                    matrix[row, col] = currentPalindrome;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
