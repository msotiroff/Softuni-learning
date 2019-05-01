namespace P06.TargetPractice
{
    using System;
    using System.Linq;

    public class TargetPractice
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var columns = dimensions[1];

            var snake = Console.ReadLine().ToCharArray();

            var matrix = new char[rows][];

            FillMatrixWithSnakes(matrix, snake, columns);

            var shotParams = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var impactRow = shotParams[0];
            var impactColumn = shotParams[1];
            var radius = shotParams[2];

            // Sets the destroyed fields to ' ':
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int column = 0; column < matrix[row].Length; column++)
                {
                    var sumPowerOfCathetus = Math.Pow(column - impactColumn, 2) + Math.Pow(row - impactRow, 2);
                    var distance = Math.Sqrt(sumPowerOfCathetus);

                    if (distance <= radius)
                    {
                        matrix[row][column] = ' ';
                    }
                }
            }

            // Swaps down the survived fields:
            for (int column = 0; column < columns; column++)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int row = matrix.Length - 1; row >= 0; row--)
                    {
                        var currentField = matrix[row][column];

                        if (currentField == ' ')
                        {
                            SwapUpElement(matrix, row, column);
                        }
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void SwapUpElement(char[][] matrix, int row, int column)
        {
            if (IsInMatrix(matrix, row - 1, column))
            {
                matrix[row][column] = matrix[row - 1][column];
                matrix[row - 1][column] = ' ';
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool IsInMatrix(char[][] matrix, int row, int column)
        {
            var result = row >= 0
                && row < matrix.Length
                && column >= 0
                && column < matrix[row].Length;

            return result;
        }

        private static void FillMatrixWithSnakes(char[][] matrix, char[] snake, int columns)
        {
            var snakeIndex = 0;

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[columns];

                var rowDirectionReminder = (matrix.Length - 1) % 2;

                if (row % 2 == rowDirectionReminder)
                {
                    for (int col = columns - 1; col >= 0; col--)
                    {
                        matrix[row][col] = snake[snakeIndex % snake.Length];
                        snakeIndex++;
                    }
                }
                else
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = snake[snakeIndex % snake.Length];
                        snakeIndex++;
                    }
                }

            }
        }
    }
}