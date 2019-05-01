namespace P01.BunkerBuster
{
    using System;
    using System.Linq;

    class StartUp
    {
        private static int rowsCount;
        private static int columnsCount;
        private static int[][] matrix;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rowsCount = dimensions.First();
            columnsCount = dimensions.Last();

            matrix = new int[rowsCount][];

            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
            }

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "cease fire!")
            {
                // Input format: [row] [column] [power]
                var inputArgs = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var targetRow = int.Parse(inputArgs[0]);
                var targetCol = int.Parse(inputArgs[1]);
                var damagePower = (int)char.Parse(inputArgs[2]);

                DestroyCells(targetRow, targetCol, damagePower);
            }

            var damagedCells = 0;
            foreach (var row in matrix)
            {
                damagedCells += row.Where(c => c <= 0).Count();
            }

            var damageRelative = (double)damagedCells / (rowsCount * columnsCount) * 100;

            Console.WriteLine("Destroyed bunkers: {0}", damagedCells);
            Console.WriteLine("Damage done: {0:f1} %", damageRelative);
        }

        private static void DestroyCells(int targetRow, int targetCol, int damagePower)
        {
            var halfDamagePower = (int)Math.Ceiling((double)damagePower / 2);

            for (int rowIndex = targetRow - 1; rowIndex <= targetRow + 1; rowIndex++)
            {
                for (int colIndex = targetCol - 1; colIndex <= targetCol + 1; colIndex++)
                {
                    if (IsInMatrix(rowIndex, colIndex))
                    {
                        if (rowIndex.Equals(targetRow) && colIndex.Equals(targetCol))
                        {
                            matrix[rowIndex][colIndex] -= damagePower;
                        }
                        else
                        {
                            matrix[rowIndex][colIndex] -= halfDamagePower;
                        }
                    }
                }
            }
        }

        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0
                && row < rowsCount
                && col >= 0
                && col < columnsCount;
        }
    }
}
