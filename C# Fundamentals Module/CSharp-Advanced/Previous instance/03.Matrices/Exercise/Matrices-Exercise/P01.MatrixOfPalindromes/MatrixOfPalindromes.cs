namespace P01.MatrixOfPalindromes
{
    using System;
    using System.Linq;

    public class MatrixOfPalindromes
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int columns = input[1];

            var matrix = new string[rows][];

            for (char firstSymbol = 'a'; firstSymbol < 'a' + rows; firstSymbol++)
            {
                var currentRow = Convert.ToInt32(firstSymbol) - 97;

                matrix[currentRow] = new string[columns];

                for (char middle = firstSymbol; middle < firstSymbol + columns; middle++)
                {
                    var currentColumn = Convert.ToInt32(middle) - firstSymbol;

                    var currentPalindrom = $"{firstSymbol}{middle}{firstSymbol}";

                    matrix[currentRow][currentColumn] = currentPalindrom;
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(string[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
