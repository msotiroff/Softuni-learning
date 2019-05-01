namespace P05.RubiksMatrix
{
    using System;
    using System.Linq;

    class RubiksMatrix
    {
        private static int[][] matrix;
        private static int rowsCount;
        private static int columnsCount;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rowsCount = dimensions[0];
            columnsCount = dimensions[1];

            matrix = InitializeMatrix(rowsCount, columnsCount);

            var countOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCommands; i++)
            {
                // Input format: {row/col index} {direction} {moves}
                var inputArgs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var index = int.Parse(inputArgs[0]);
                var direction = inputArgs[1];
                var moves = int.Parse(inputArgs[2]);

                switch (direction.ToLower())
                {
                    case "up":
                        ExecuteUpCommand(index, moves);
                        break;
                    case "down":
                        ExecuteDownCommand(index, moves);
                        break;
                    case "left":
                        ExecuteLeftCommand(index, moves);
                        break;
                    case "right":
                        ExecuteRightCommand(index, moves);
                        break;
                    default:
                        break;
                }
            }

            RearrangeMatrix();
        }

        private static void RearrangeMatrix()
        {
            var counter = 1;

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < columnsCount; col++)
                {
                    if (matrix[row][col].Equals(counter))
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
                        {
                            var elementFound = false;

                            for (int columnIndex = 0; columnIndex < columnsCount; columnIndex++)
                            {
                                if (matrix[rowIndex][columnIndex].Equals(counter))
                                {
                                    matrix[rowIndex][columnIndex] = matrix[row][col];
                                    matrix[row][col] = counter;

                                    Console.WriteLine($"Swap ({row}, {col}) with ({rowIndex}, {columnIndex})");

                                    elementFound = true;
                                    break;
                                }
                            }
                            
                            if (elementFound)
                            {
                                break;
                            }
                        }
                    }

                    counter++;
                }
            }
        }

        private static void ExecuteRightCommand(int rowIndex, int moves)
        {
            for (int move = 0; move < moves % columnsCount; move++)
            {
                var lastElement = matrix[rowIndex][columnsCount - 1];

                for (int col = columnsCount - 1; col >= 1; col--)
                {
                    var leftElement = matrix[rowIndex][col - 1];
                    matrix[rowIndex][col] = leftElement;
                }

                matrix[rowIndex][0] = lastElement;
            }
        }

        private static void ExecuteLeftCommand(int rowIndex, int moves)
        {
            for (int move = 0; move < moves % columnsCount; move++)
            {
                var firstElement = matrix[rowIndex][0];

                for (int col = 0; col < columnsCount - 1; col++)
                {
                    var rightElement = matrix[rowIndex][col + 1];
                    matrix[rowIndex][col] = rightElement;
                }

                matrix[rowIndex][columnsCount - 1] = firstElement;
            }
        }

        private static void ExecuteDownCommand(int columnIndex, int moves)
        {
            for (int move = 0; move < moves % rowsCount; move++)
            {
                var lastElement = matrix[rowsCount - 1][columnIndex];

                for (int row = rowsCount - 1; row >= 1; row--)
                {
                    var upperElement = matrix[row - 1][columnIndex];
                    matrix[row][columnIndex] = upperElement;
                }

                matrix[0][columnIndex] = lastElement;
            }
        }

        private static void ExecuteUpCommand(int columnIndex, int moves)
        {
            for (int move = 0; move < moves % rowsCount; move++)
            {
                var firstElement = matrix[0][columnIndex];

                for (int row = 0; row < rowsCount - 1; row++)
                {
                    var beneathElement = matrix[row + 1][columnIndex];
                    matrix[row][columnIndex] = beneathElement;
                }

                matrix[rowsCount - 1][columnIndex] = firstElement;
            }
        }

        private static int[][] InitializeMatrix(int rowsCount, int columnsCount)
        {
            var matrix = new int[rowsCount][];
            var counter = 1;

            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = new int[columnsCount];

                for (int col = 0; col < columnsCount; col++)
                {
                    matrix[row][col] = counter;
                    counter++;
                }
            }

            return matrix;
        }
    }
}
