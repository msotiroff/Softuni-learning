namespace P11.ParkingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ParkingSystem
    {
        static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rowsCount = sizes[0];
            var columnsCount = sizes[1];

            var parking = new Dictionary<int, HashSet<int>>();

            string command;
            while ((command = Console.ReadLine()) != "stop")
            {
                var commandArgs = command
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var entryRow = commandArgs[0];
                var targetRow = commandArgs[1];
                var targetColumn = commandArgs[2];

                if (!parking.ContainsKey(targetRow))
                {
                    parking[targetRow] = new HashSet<int>();
                }

                var distance = Math.Abs(entryRow - targetRow) + 1;
                var isParked = false;

                if (!parking[targetRow].Contains(targetColumn))
                {
                    distance += targetColumn;
                    isParked = true;
                    parking[targetRow].Add(targetColumn);
                }
                else
                {
                    var maxLength = Math.Max(targetColumn - 1, columnsCount - 1 - targetColumn);

                    for (int move = 1; move <= maxLength; move++)
                    {
                        if (IsInParking(targetColumn - move, columnsCount) && !parking[targetRow].Contains(targetColumn - move))
                        {
                            distance += targetColumn - move;
                            isParked = true;
                            parking[targetRow].Add(targetColumn - move);
                            break;
                        }
                        else if (IsInParking(targetColumn + move, columnsCount) && !parking[targetRow].Contains(targetColumn + move))
                        {
                            distance += targetColumn + move;
                            isParked = true;
                            parking[targetRow].Add(targetColumn + move);
                            break;
                        }
                    }
                }

                Console.WriteLine(isParked ? distance.ToString() : $"Row {targetRow} full");
            }
        }

        private static bool IsInParking(int column, int columnsCount)
        {
            return column > 0 && column < columnsCount;
        }
    }
}
