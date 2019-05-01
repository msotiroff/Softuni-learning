namespace P11.ParkingSystemUsingDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ParkingSystemAnother
    {
        private static Dictionary<int, HashSet<int>> occupiedCells;
        private static int rows;
        private static int columns;

        public static void Main(string[] args)
        {
            occupiedCells = new Dictionary<int, HashSet<int>>();

            var parkingSizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rows = parkingSizes[0];
            columns = parkingSizes[1];

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "stop")
            {
                var inputParams = inputLine
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var entryRow = inputParams[0];
                var targetRow = inputParams[1];
                var targetColumn = inputParams[2];

                var isTargetCellOccupied = IsTargetCellOccupied(targetRow, targetColumn);

                var result = 0;

                if (isTargetCellOccupied)
                {
                    targetColumn = FindFreeCell(targetRow, targetColumn);
                }

                if (targetColumn > 0)
                {
                    if (!occupiedCells.ContainsKey(targetRow))
                    {
                        occupiedCells[targetRow] = new HashSet<int>();
                    }
                    occupiedCells[targetRow].Add(targetColumn);

                    result = Math.Abs(targetRow - entryRow) + 1 + targetColumn;
                }

                Console.WriteLine(targetColumn > 0 ? result.ToString() : $"Row {targetRow} full");
            }
        }

        private static int FindFreeCell(int targetRow, int targetColumn)
        {
            var newColumnIndex = 0;
            var maxLenght = columns;

            for (int index = 1; index < columns; index++)
            {
                if (!IsTargetCellOccupied(targetRow, index))
                {
                    int newLength = Math.Abs(targetColumn - index);
                    if (newLength < maxLenght)
                    {
                        maxLenght = newLength;
                        newColumnIndex = index;
                    }
                }
            }

            return newColumnIndex;
        }

        private static bool IsTargetCellOccupied(int targetRow, int targetColumn)
        {
            var result = false;

            if (occupiedCells.ContainsKey(targetRow))
            {
                if (occupiedCells[targetRow].Contains(targetColumn))
                {
                    result = true;
                }
            }

            return result;
        }
    }
}
