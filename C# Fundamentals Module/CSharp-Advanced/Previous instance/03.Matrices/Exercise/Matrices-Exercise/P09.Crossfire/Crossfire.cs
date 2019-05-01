namespace P09.Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Crossfire
    {
        public static void Main(string[] args)
        {
            var matrixSizes = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var rows = matrixSizes[0];
            var columns = matrixSizes[1];

            var matrix = new List<List<int>>();

            FillMatrix(matrix, rows, columns);

            string inputCommand;
            while ((inputCommand = Console.ReadLine()) != "Nuke it from orbit")
            {
                var inputParams = inputCommand
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var shottedRow = inputParams[0];
                var shottedColumn = inputParams[1];
                var radius = inputParams[2];

                DestructMatrix(matrix, shottedRow, shottedColumn, radius);
                RemoveShottedFields(matrix);
            }

            PrintMatrix(matrix);
        }

        private static void RemoveShottedFields(List<List<int>> matrix)
        {
            for (int row = 0; row < matrix.Count; row++)
            {
                if (matrix[row].Count > 0)
                {
                    matrix[row].RemoveAll(c => c == 0);
                    if (!matrix[row].Any())
                    {
                        matrix.RemoveAt(row);
                        row--;
                    }
                }
                else
                {
                    matrix.RemoveAt(row);
                    row--;
                }
            }
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static void DestructMatrix(List<List<int>> matrix, int shottedRow, int shottedColumn, int radius)
        {
            if (shottedRow >= 0 && shottedRow < matrix.Count)
            {
                var columnMinIndex = Math.Max(0, shottedColumn - radius);
                var columnMaxIndex = Math.Min(shottedColumn + radius, matrix[shottedRow].Count - 1);

                for (int column = columnMinIndex; column <= columnMaxIndex; column++)
                {
                    matrix[shottedRow][column] = 0;
                }
            }
            
            if (shottedColumn >= 0 && shottedColumn < matrix[0].Count)
            {
                var rowMinIndex = Math.Max(0, shottedRow - radius);
                var rowMaxIndex = Math.Min(shottedRow + radius, matrix.Count - 1);

                for (int row = rowMinIndex; row <= rowMaxIndex; row++)
                {
                    if (shottedColumn < matrix[row].Count)
                    {
                        matrix[row][shottedColumn] = 0;
                    }
                }
            }
        }

        private static void FillMatrix(List<List<int>> matrix, int rowsCount, int columnsCount)
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
