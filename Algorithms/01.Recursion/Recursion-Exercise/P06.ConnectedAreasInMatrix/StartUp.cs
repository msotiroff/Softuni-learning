namespace P06.ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        private const char Wall = '*';
        private const char Visited = 'v';

        private static char[,] matrix;
        private static int rowsCount;
        private static int columnsCount;

        private static SortedSet<Area> areas = new SortedSet<Area>();

        public static void Main(string[] args)
        {
            ReadMatrix();

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < columnsCount; col++)
                {
                    FindConnectedArea(matrix, row, col);
                }
            }

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine($"Total areas found: {areas.Count}");

            var counter = 0;

            foreach (var area in areas)
            {
                Console.WriteLine($"Area #{++counter} at ({area.Row}, {area.Column}), size: {area.Size}");
            }
        }

        private static void FindConnectedArea(char[,] matrix, int row, int column)
        {
            if (matrix[row, column] == Wall || matrix[row, column] == Visited)
            {
                return;
            }

            var area = new Area(row, column);
            FillArea(matrix, row, column, area);

            areas.Add(area);
        }

        private static void FillArea(char[,] matrix, int row, int column, Area area)
        {
            if (!IsInBoundsOfMatrix(row, column) 
                || matrix[row, column] == Wall
                || matrix[row, column] == Visited)
            {
                return;
            }

            matrix[row, column] = Visited;
            area.IncreaseSize();

            FillArea(matrix, row + 1, column, area);
            FillArea(matrix, row, column + 1, area);
            FillArea(matrix, row - 1, column, area);
            FillArea(matrix, row, column - 1, area);
        }

        private static bool IsInBoundsOfMatrix(int row, int col) 
            => row >= 0 && row < rowsCount && col >= 0 && col < columnsCount;

        private static void ReadMatrix()
        {
            rowsCount = int.Parse(Console.ReadLine());
            columnsCount = int.Parse(Console.ReadLine());

            matrix = new char[rowsCount, columnsCount];

            for (int row = 0; row < rowsCount; row++)
            {
                var currentRow = Console.ReadLine();

                for (int col = 0; col < columnsCount; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
        }
    }

    public class Area : IComparable<Area>
    {
        public Area(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            this.Size = 0;
        }

        public int Row { get; private set; }

        public int Column { get; private set; }

        public int Size { get; private set; }

        public void IncreaseSize() => this.Size++;

        public int CompareTo(Area other)
        {
            var result = other.Size.CompareTo(this.Size);
            if (result == 0)
            {
                result = this.Row.CompareTo(other.Row);
                if (result == 0)
                {
                    result = this.Column.CompareTo(other.Column);
                }
            }

            return result;
        }
    }
}
