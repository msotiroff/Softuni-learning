namespace P07.PathsInLabyrinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static char[,] labyrinth;
        private static bool[,] visitedCells;
        private static List<char> path = new List<char>();

        public static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            int colsCount = int.Parse(Console.ReadLine());

            labyrinth = ReadLabyrinth(rowsCount, colsCount);
            visitedCells = new bool[rowsCount, colsCount];

            FindPaths(0, 0, 'S');
        }

        private static void FindPaths(int row, int column, char direction)
        {
            if (!IsInBoundsOfLabyrinth(row, column))
            {
                return;
            }

            path.Add(direction);

            if (labyrinth[row, column] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, path.Skip(1)));
            }
            else if (!IsVisited(row, column) && IsFree(row, column))
            {
                Mark(row, column);
                FindPaths(row, column + 1, 'R');
                FindPaths(row + 1, column, 'D');
                FindPaths(row, column - 1, 'L');
                FindPaths(row - 1, column, 'U');
                Unmark(row, column);
            }

            path.RemoveAt(path.Count - 1);
        }

        private static void Unmark(int row, int column)
        {
            visitedCells[row, column] = false;
        }

        private static void Mark(int row, int column)
        {
            visitedCells[row, column] = true;
        }

        private static bool IsFree(int row, int column)
        {
            return labyrinth[row, column] != '*';
        }

        private static bool IsVisited(int row, int column)
        {
            return visitedCells[row, column];
        }

        private static bool IsInBoundsOfLabyrinth(int row, int column)
        {
            return row >= 0
                && row < labyrinth.GetLength(0)
                && column >= 0
                && column < labyrinth.GetLength(1);
        }

        private static char[,] ReadLabyrinth(int rowsCount, int colsCount)
        {
            var matrix = new char[rowsCount, colsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            return matrix;
        }
    }
}
