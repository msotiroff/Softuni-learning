namespace P08.RadioactiveBunnies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RadioactiveBunnies
    {
        public static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSizes[0];
            var columns = matrixSizes[1];

            var bunniesLair = new char[rows][];

            FillLair(rows, bunniesLair);

            var commands = Console.ReadLine().ToUpper().ToCharArray();

            Point playerPosition = FindPlayerPosition(bunniesLair);
            Player player = new Player(playerPosition);

            foreach (var command in commands)
            {
                MovePlayer(player, bunniesLair, command);
                
                SpreadsBunnies(bunniesLair, player);

                if (player.IsWinner)
                {
                    PrintLair(bunniesLair);
                    Console.WriteLine($"won: {player.Position.Row} {player.Position.Column}");
                    Environment.Exit(0);
                }
                else if (!player.IsAlive)
                {
                    PrintLair(bunniesLair);
                    Console.WriteLine($"dead: {player.Position.Row} {player.Position.Column}");
                    Environment.Exit(0);
                }
            }
        }

        private static void PrintLair(char[][] bunniesLair)
        {
            foreach (var row in bunniesLair)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void SpreadsBunnies(char[][] bunniesLair, Player player)
        {
            var bunniesPositions = new List<Point>();

            for (int row = 0; row < bunniesLair.Length; row++)
            {
                for (int col = 0; col < bunniesLair[row].Length; col++)
                {
                    if (bunniesLair[row][col] == 'B')
                    {
                        var upPoint = new Point(row - 1, col);
                        var downPoint = new Point(row + 1, col);
                        var rightPoint = new Point(row, col + 1);
                        var leftPoint = new Point(row, col - 1);

                        bunniesPositions
                            .AddRange(new Point[]
                            {
                                upPoint,
                                downPoint,
                                leftPoint,
                                rightPoint
                            });
                    }
                }
            }

            foreach (var position in bunniesPositions)
            {
                if (IsInRangeOfLair(bunniesLair, position.Row, position.Column))
                {
                    if (bunniesLair[position.Row][position.Column] != 'B')
                    {
                        if (bunniesLair[position.Row][position.Column] == 'P')
                        {
                            player.IsAlive = false;
                        }

                        bunniesLair[position.Row][position.Column] = 'B';
                    }
                }
            }
        }

        private static void MovePlayer(Player player, char[][] bunniesLair, char direction)
        {
            var currentPosition = new Point(player.Position.Row, player.Position.Column);

            switch (direction)
            {
                case 'U':
                    player.Position.Row--;
                    break;
                case 'D':
                    player.Position.Row++;
                    break;
                case 'L':
                    player.Position.Column--;
                    break;
                case 'R':
                    player.Position.Column++;
                    break;
                default:
                    break;
            }

            // Debugging:
            if (player.Position.Column == 1)
            {
                Console.WriteLine();
            }

            if (IsInRangeOfLair(bunniesLair, player.Position.Row, player.Position.Column))
            {
                if (!IsFieldFreeOfBunnies(bunniesLair, player.Position.Row, player.Position.Column))
                {
                    player.IsAlive = false;
                }
                else
                {
                    bunniesLair[player.Position.Row][player.Position.Column] = 'P';
                    bunniesLair[currentPosition.Row][currentPosition.Column] = '.';
                }
            }
            else
            {
                player.IsWinner = true;
                player.Position = currentPosition;
                bunniesLair[player.Position.Row][player.Position.Column] = '.';
            }
        }

        private static bool IsFieldFreeOfBunnies(char[][] bunniesLair, int row, int column)
        {
            var result = true;

            if (bunniesLair[row][column] == 'B')
            {
                result = false;
            }

            return result;
        }

        private static bool IsInRangeOfLair(char[][] bunniesLair, int row, int column)
        {
            var result = row >= 0
                && row < bunniesLair.Length
                && column >= 0
                && column < bunniesLair[row].Length;

            return result;
        }

        private static Point FindPlayerPosition(char[][] bunniesLair)
        {
            int row = 0;
            int column = 0;
            var playerFound = false;

            for (int i = 0; i < bunniesLair.Length; i++)
            {
                for (int j = 0; j < bunniesLair[row].Length; j++)
                {
                    if (bunniesLair[i][j] == 'P')
                    {
                        row = i;
                        column = j;
                        playerFound = true;
                        break;
                    }
                }

                if (playerFound)
                {
                    break;
                }
            }

            var position = new Point(row, column);

            return position;
        }

        private static void FillLair(int rows, char[][] bunniesLair)
        {
            for (int row = 0; row < rows; row++)
            {
                var currentRow = Console.ReadLine().ToCharArray();

                bunniesLair[row] = currentRow;
            }
        }
    }
}
