namespace P05.RubiksMatrix
{
    using System;
    using System.Linq;
    using System.Text;

    public class RubiksMatrix
    {
        public static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSizes[0];
            var columns = matrixSizes[1];

            var matrix = new int[rows][];

            SeedMatrix(matrix, rows, columns);

            var countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                var currentCommand = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var dimension = int.Parse(currentCommand[0]);
                var direction = currentCommand[1];
                var moves = int.Parse(currentCommand[2]);

                switch (direction)
                {
                    case "left":
                        MoveLeft(matrix, dimension, moves);
                        break;
                    case "right":
                        MoveRight(matrix, dimension, moves);
                        break;
                    case "up":
                        MoveUp(matrix, dimension, moves);
                        break;
                    case "down":
                        MoveDown(matrix, dimension, moves);
                        break;
                    default:
                        break;
                }
            }

            string result = RearrangeMatrix(matrix);

            Console.WriteLine(result);
        }

        private static string RearrangeMatrix(int[][] matrix)
        {
            var builder = new StringBuilder();

            var searchedElement = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int column = 0; column < matrix[row].Length; column++)
                {
                    if (matrix[row][column] != searchedElement)
                    {
                        // Find and swap searched element:
                        var neededElementFound = false;

                        for (int neededRow = row; neededRow < matrix.Length; neededRow++)
                        {
                            if (neededElementFound)
                            {
                                break;
                            }

                            for (int neededColumn = 0; neededColumn < matrix[neededRow].Length; neededColumn++)
                            {
                                var currentElement = matrix[neededRow][neededColumn];

                                if (currentElement == searchedElement)
                                {
                                    // Swaps the two elements:
                                    matrix[neededRow][neededColumn] = matrix[row][column];
                                    matrix[row][column] = currentElement;

                                    // Add the current swap to the log!
                                    string lineToAppend = $"Swap ({row}, {column}) with ({neededRow}, {neededColumn})";
                                    builder.AppendLine(lineToAppend);

                                    // Returns to next unsorted element!
                                    neededElementFound = true;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        builder.AppendLine("No swap required");
                    }

                    // Increases the searched element to next number!
                    searchedElement++;
                }
            }

            var result = builder.ToString().TrimEnd();

            return result;
        }

        private static void MoveLeft(int[][] matrix, int row, int moves)
        {
            for (int i = 0; i < moves % matrix[row].Length; i++)
            {
                int firstElement = matrix[row][0];

                for (int column = 0; column < matrix[row].Length - 1; column++)
                {
                    matrix[row][column] = matrix[row][column + 1];
                }

                matrix[row][matrix[row].Length - 1] = firstElement;
            }
        }

        private static void MoveRight(int[][] matrix, int row, int moves)
        {
            for (int i = 0; i < moves % matrix[row].Length; i++)
            {
                int lastElement = matrix[row][matrix[row].Length - 1];

                for (int column = matrix[row].Length - 1; column > 0; column--)
                {
                    matrix[row][column] = matrix[row][column - 1];
                }

                matrix[row][0] = lastElement;
            }
        }

        private static void MoveDown(int[][] matrix, int column, int moves)
        {
            for (int i = 0; i < moves % matrix.Length; i++)
            {
                int lastElement = matrix[matrix.Length - 1][column];

                for (int row = matrix.Length - 1; row > 0; row--)
                {
                    matrix[row][column] = matrix[row - 1][column];
                }

                matrix[0][column] = lastElement;
            }
        }

        private static void MoveUp(int[][] matrix, int column, int moves)
        {
            for (int i = 0; i < moves % matrix.Length; i++)
            {
                int firstElement = matrix[0][column];

                for (int row = 0; row < matrix.Length - 1; row++)
                {
                    matrix[row][column] = matrix[row + 1][column];
                }

                matrix[matrix.Length - 1][column] = firstElement;
            }
        }

        private static void SeedMatrix(int[][] matrix, int rows, int columns)
        {
            var counter = 1;

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[columns];

                for (int column = 0; column < columns; column++)
                {
                    matrix[row][column] = counter;
                    counter++;
                }
            }
        }
    }
}
