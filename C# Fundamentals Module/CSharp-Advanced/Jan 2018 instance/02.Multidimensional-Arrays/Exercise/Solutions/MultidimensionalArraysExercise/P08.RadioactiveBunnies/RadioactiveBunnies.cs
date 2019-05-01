namespace P08.RadioactiveBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RadioactiveBunnies
    {
        private static char[][] matrix;
        private static int rowsCount;
        private static int columnsCount;
        private static int playerRow;
        private static int playerCol;
        private static bool isAlive;
        private static bool isWinner;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            isAlive = true;
            isWinner = false;

            rowsCount = dimensions.First();
            columnsCount = dimensions.Last();

            matrix = new char[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();

                if (matrix[i].Contains('P'))
                {
                    playerRow = i;
                    playerCol = Array.IndexOf(matrix[i], 'P');
                }
            }



            var moves = Console.ReadLine();

            for (int moveIndex = 0; moveIndex < moves.Length; moveIndex++)
            {
                var currentMove = moves[moveIndex];

                switch (currentMove)
                {
                    case 'U':
                        MoveUp();
                        break;
                    case 'D':
                        MoveDown();
                        break;
                    case 'L':
                        MoveLeft();
                        break;
                    case 'R':
                        MoveRight();
                        break;

                    default:
                        break;
                }

                if (isWinner)
                {
                    PrintMatrix();
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    Environment.Exit(0);
                }
                else if (!isAlive)
                {
                    PrintMatrix();
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    Environment.Exit(0);
                }
            }
        }

        private static void MoveRight()
        {
            if (IsInBoundsOfMatrix(playerRow, playerCol + 1))
            {
                if (matrix[playerRow][playerCol + 1] != 'B')
                {
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow][playerCol + 1] = 'P';
                }
                else
                {
                    isAlive = false;
                }

                playerCol += 1;

                BunniesBreeding();
            }
            else
            {
                isWinner = true;
                matrix[playerRow][playerCol] = '.';
                BunniesBreeding();
            }
        }

        private static void MoveDown()
        {
            if (IsInBoundsOfMatrix(playerRow + 1, playerCol))
            {
                if (matrix[playerRow + 1][playerCol] != 'B')
                {
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow + 1][playerCol] = 'P';
                }
                else
                {
                    isAlive = false;
                }

                playerRow += 1;

                BunniesBreeding();
            }
            else
            {
                isWinner = true;
                matrix[playerRow][playerCol] = '.';
                BunniesBreeding();
            }
        }

        private static void MoveLeft()
        {
            if (IsInBoundsOfMatrix(playerRow, playerCol - 1))
            {
                if (matrix[playerRow][playerCol - 1] != 'B')
                {
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow][playerCol - 1] = 'P';
                }
                else
                {
                    isAlive = false;
                }

                playerCol -= 1;

                BunniesBreeding();
            }
            else
            {
                isWinner = true;
                matrix[playerRow][playerCol] = '.';
                BunniesBreeding();
            }
        }

        private static void MoveUp()
        {
            if (IsInBoundsOfMatrix(playerRow - 1, playerCol))
            {
                if (matrix[playerRow - 1][playerCol] != 'B')
                {
                    matrix[playerRow][playerCol] = '.';
                    matrix[playerRow - 1][playerCol] = 'P';
                }
                else
                {
                    isAlive = false;
                }

                playerRow -= 1;

                BunniesBreeding();
            }
            else
            {
                isWinner = true;
                matrix[playerRow][playerCol] = '.';
                BunniesBreeding();
            }
        }

        private static void BunniesBreeding()
        {
            var indexes = new List<Cell>();

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < columnsCount; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        indexes.Add(new Cell(row - 1, col));
                        indexes.Add(new Cell(row + 1, col));
                        indexes.Add(new Cell(row, col - 1));
                        indexes.Add(new Cell(row, col + 1));
                    }
                }
            }

            foreach (var index in indexes)
            {
                if (IsInBoundsOfMatrix(index.Row, index.Column))
                {
                    if (matrix[index.Row][index.Column] == 'P')
                    {
                        isAlive = false;
                    }
                    matrix[index.Row][index.Column] = 'B';
                }
            }
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static bool IsInBoundsOfMatrix(int row, int col)
        {
            return row >= 0
                && row < rowsCount
                && col >= 0
                && col < columnsCount;
        }
    }
}
