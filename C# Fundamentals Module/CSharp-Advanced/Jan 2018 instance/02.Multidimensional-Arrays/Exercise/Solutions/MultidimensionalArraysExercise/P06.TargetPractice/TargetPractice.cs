namespace P06.TargetPractice
{
    using System;
    using System.Linq;

    class TargetPractice
    {
        private static char[][] matrix;
        private static int rowsCount;
        private static int colulmnsCount;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            rowsCount = dimensions.First();
            colulmnsCount = dimensions.Last();

            matrix = new char[rowsCount][];

            // Initialize matrix with default values -> ' '
            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = new char[colulmnsCount];
            }

            var snake = Console.ReadLine().ToCharArray();

            FillMatrix(snake);

            var shootArgs = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var targetRow = shootArgs[0];
            var targetColumn = shootArgs[1];
            var radius = shootArgs[2];

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < colulmnsCount; col++)
                {
                    // (x - center_x)^2 + (y - center_y)^2 <= radius^2

                    var distance = Math.Pow(Math.Abs(row - targetRow), 2) + Math.Pow(Math.Abs(col - targetColumn), 2);
                    distance = Math.Sqrt(distance);

                    if (distance <= radius)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }

            for (int col = 0; col < colulmnsCount; col++)
            {
                for (int move = 0; move < rowsCount; move++)
                {
                    for (int row = rowsCount - 1; row >= 1; row--)
                    {
                        if (matrix[row][col].Equals(' '))
                        {
                            for (int currRow = row; currRow >= 1; currRow--)
                            {
                                var upperElement = matrix[currRow - 1][col];

                                matrix[currRow][col] = upperElement;
                            }

                            matrix[0][col] = ' ';
                        }
                    }
                }
            }
                

            // Print matrix:
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void FillMatrix(char[] snake)
        {
            var snakeLength = snake.Length;
            var snakeIndexCounter = 0;

            var isLeftward = true;

            for (int row = rowsCount - 1; row >= 0; row--)
            {
                if (isLeftward)
                {
                    for (int col = colulmnsCount - 1; col >= 0; col--)
                    {
                        matrix[row][col] = snake[snakeIndexCounter % snakeLength];
                        snakeIndexCounter++;
                    }

                    isLeftward = false;
                }
                else
                {
                    for (int col = 0; col < colulmnsCount; col++)
                    {
                        matrix[row][col] = snake[snakeIndexCounter % snakeLength];
                        snakeIndexCounter++;
                    }

                    isLeftward = true;
                }
            }
        }
    }
}
