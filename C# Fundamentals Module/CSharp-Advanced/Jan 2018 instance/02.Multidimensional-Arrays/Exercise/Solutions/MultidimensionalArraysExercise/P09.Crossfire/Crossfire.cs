namespace P09.Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Crossfire
    {
        private static List<List<int>> matrix;
        private static int rowsCount;
        private static int columnsCount;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rowsCount = dimensions.First();
            columnsCount = dimensions.Last();

            matrix = new List<List<int>>();
            FillMatrix();

            string input;
            while ((input = Console.ReadLine()) != "Nuke it from orbit")
            {
                var inputArgs = input
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var targetRow = inputArgs[0];
                var targetCol = inputArgs[1];
                var radius = inputArgs[2];

                DestroyCells(targetRow, targetCol, radius);
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void DestroyCells(int targetRow, int targetCol, int radius)
        {
            for (int row = targetRow - radius; row <= targetRow + radius; row++)
            {
                if (IsExisting(row, targetCol))
                {
                    matrix[row][targetCol] = 0;
                }
            }

            for (int col = targetCol - radius; col <= targetCol + radius; col++)
            {
                if (IsExisting(targetRow, col))
                {
                    matrix[targetRow][col] = 0;
                }
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                matrix[i].RemoveAll(e => e == 0);
                if (!matrix[i].Any())
                {
                    matrix.RemoveAt(i);
                    i--;
                }
            }
        }

        private static bool IsExisting(int row, int col)
        {
            return row >= 0
                && row < matrix.Count
                && col >= 0
                && col < matrix[row].Count;
        }

        private static void FillMatrix()
        {
            int counter = 1;

            for (int row = 0; row < rowsCount; row++)
            {
                matrix.Add(new List<int>());
                for (int col = 0; col < columnsCount; col++)
                {
                    matrix[row].Add(counter);
                    counter++;
                }
            }
        }
    }
}
