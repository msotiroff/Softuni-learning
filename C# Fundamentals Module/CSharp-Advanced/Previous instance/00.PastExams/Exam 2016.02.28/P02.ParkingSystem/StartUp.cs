namespace P02.ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        private static Dictionary<int, HashSet<int>> occupiedCells;
        private static int rowsCount;
        private static int columnsCount;

        static void Main(string[] args)
        {
            occupiedCells = new Dictionary<int, HashSet<int>>();

            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            rowsCount = dimensions[0];
            columnsCount = dimensions[1];

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "stop")
            {
                var inputParams = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var entryRow = inputParams[0];
                var targetRow = inputParams[1];
                var targetCol = inputParams[2];

                if (!occupiedCells.ContainsKey(targetRow))
                {
                    occupiedCells[targetRow] = new HashSet<int>();
                }

                string result = TryParkTheCurrentCar(entryRow, targetRow, targetCol);

                Console.WriteLine(result);
            }
        }

        private static string TryParkTheCurrentCar(int entryRow, int targetRow, int targetCol)
        {
            if (occupiedCells[targetRow].Count == columnsCount - 1)
            {
                return $"Row {targetRow} full";
            }

            var moves = Math.Abs(targetRow - entryRow) + 1;

            var maxMoves = Math.Max(targetCol - 1, columnsCount - targetCol);

            if (IsInParking(targetRow, targetCol) && !occupiedCells[targetRow].Contains(targetCol))
            {
                occupiedCells[targetRow].Add(targetCol);
                moves += targetCol;

                return moves.ToString();
            }

            for (int move = 1; move <= maxMoves; move++)
            {
                if (IsInParking(targetRow, targetCol - move)
                    && !occupiedCells[targetRow].Contains(targetCol - move))
                {
                    occupiedCells[targetRow].Add(targetCol - move);
                    moves += targetCol - move;

                    return moves.ToString();
                }

                if (IsInParking(targetRow, targetCol + move)
                    && !occupiedCells[targetRow].Contains(targetCol + move))
                {
                    occupiedCells[targetRow].Add(targetCol + move);
                    moves += targetCol + move;

                    return moves.ToString();
                }
            }

            return $"Row {targetRow} full";
        }

        private static bool IsInParking(int row, int column)
        {
            return row >= 0
                && row < rowsCount
                && column > 0
                && column < columnsCount;

        }
    }
}
