namespace P06_Sneaking
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int roomRows;
        private static int roomColumns;
        private static char[][] room;
        private static int samCurrentRow;
        private static int samCurrentCol;
        private static int nikoladzeRow;
        private static int nikoladzeCol;

        public static void Main(string[] args)
        {
            roomRows = int.Parse(Console.ReadLine());
            room = new char[roomRows][];

            InitializeRoomPositions();
            roomColumns = room[0].Length;

            var directions = Console.ReadLine();

            for (int i = 0; i < directions.Length; i++)
            {
                MoveEnemies();

                CheckIsSamKilled();

                MoveSam(directions[i]);

                CheckIsNikoladzeKilled();
            }
        }

        private static void InitializeRoomPositions()
        {
            for (int rowIndex = 0; rowIndex < roomRows; rowIndex++)
            {
                var currentRow = Console.ReadLine();
                room[rowIndex] = currentRow.ToCharArray();

                var samPosition = currentRow.IndexOf('S');
                if (samPosition != -1)
                {
                    samCurrentRow = rowIndex;
                    samCurrentCol = samPosition;
                }
                var nikoladzePosition = currentRow.IndexOf('N');
                if (nikoladzePosition != -1)
                {
                    nikoladzeRow = rowIndex;
                    nikoladzeCol = nikoladzePosition;
                }
            }
        }

        private static void CheckIsNikoladzeKilled()
        {
            if (samCurrentRow == nikoladzeRow)
            {
                room[nikoladzeRow][nikoladzeCol] = 'X';
                Console.WriteLine("Nikoladze killed!");
                PrintRoom();
                Environment.Exit(0);
            }
        }

        private static void MoveSam(char currentDirection)
        {
            switch (currentDirection)
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
                case 'W':
                    break;
                default:
                    break;
            }
        }

        private static void MoveEnemies()
        {
            for (int rowIndex = 0; rowIndex < roomRows; rowIndex++)
            {
                var isEnemyTurned = false;

                for (int colIndex = 0; colIndex < roomColumns; colIndex++)
                {
                    if (room[rowIndex][colIndex].Equals('d'))
                    {
                        if (colIndex > 0)
                        {
                            room[rowIndex][colIndex] = '.';
                            room[rowIndex][colIndex - 1] = 'd';
                        }
                        else
                        {
                            room[rowIndex][colIndex] = 'b';
                            isEnemyTurned = true;
                        }
                    }
                }
                if (!isEnemyTurned)
                {
                    for (int colIndex = roomColumns - 1; colIndex >= 0; colIndex--)
                    {
                        if (room[rowIndex][colIndex].Equals('b'))
                        {
                            if (colIndex < roomColumns - 1)
                            {
                                room[rowIndex][colIndex] = '.';
                                room[rowIndex][colIndex + 1] = 'b';
                            }
                            else
                            {
                                room[rowIndex][colIndex] = 'd';
                            }
                        }
                    }
                }
            }
        }

        private static void MoveRight()
        {
            var columnToGo = samCurrentCol + 1;

            room[samCurrentRow][samCurrentCol] = '.';
            room[samCurrentRow][columnToGo] = 'S';
            samCurrentCol = columnToGo;
        }

        private static void MoveLeft()
        {
            var columnToGo = samCurrentCol - 1;

            room[samCurrentRow][samCurrentCol] = '.';
            room[samCurrentRow][columnToGo] = 'S';
            samCurrentCol = columnToGo;
        }

        private static void MoveDown()
        {
            var rowToGo = samCurrentRow + 1;

            room[samCurrentRow][samCurrentCol] = '.';
            room[rowToGo][samCurrentCol] = 'S';
            samCurrentRow = rowToGo;
        }

        private static void MoveUp()
        {
            var rowToGo = samCurrentRow - 1;

            room[samCurrentRow][samCurrentCol] = '.';
            room[rowToGo][samCurrentCol] = 'S';
            samCurrentRow = rowToGo;
        }

        private static void CheckIsSamKilled()
        {
            var samCurrRowSequence = room[samCurrentRow];

            if ((samCurrRowSequence.Contains('b') && Array.IndexOf(samCurrRowSequence, 'b') < samCurrentCol))
            {
                Console.WriteLine($"Sam died at {samCurrentRow}, {samCurrentCol}");
                room[samCurrentRow][samCurrentCol] = 'X';
                PrintRoom();
                Environment.Exit(0);
            }
            if ((samCurrRowSequence.Contains('d') && Array.IndexOf(samCurrRowSequence, 'd') > samCurrentCol))
            {
                Console.WriteLine($"Sam died at {samCurrentRow}, {samCurrentCol}");
                room[samCurrentRow][samCurrentCol] = 'X';
                PrintRoom();
                Environment.Exit(0);
            }
        }

        private static void PrintRoom()
        {
            foreach (var row in room)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}