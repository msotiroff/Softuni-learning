namespace P11.ParkingSystem
{
    using System;
    using System.Linq;

    public class ParkingSystem
    {
        // This solution works properly, but needs about 27MB of memory, 
        // so it exceeds the memory limit of 16MB in Judge System and fail 2 of 10 tests !!!
        // There is another solution using Dictionary instead of matrices and takes only 10MB of memory !!!

        public static void Main(string[] args)
        {
            var parkingSizes = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = parkingSizes[0];
            var columns = parkingSizes[1];

            var parking = new int[rows][];

            InitializeParking(parking, columns);

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "stop")
            {
                var cellParams = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var entryRow = cellParams[0];
                var targetRow = cellParams[1];
                var targetColumn = cellParams[2];

                var targetCell = new Cell(targetRow, targetColumn);

                var distanceCounter = ParkCar(parking, entryRow, targetCell);

                Console.WriteLine(distanceCounter > 0 ? distanceCounter.ToString() : $"Row {targetCell.Row} full");
            }
        }

        private static int ParkCar(int[][] parking, int entryRow, Cell targetCell)
        {
            int counter = 0;

            // Find a free cell:
            int minLoopIteration = Math.Max(parking[targetCell.Row].Length - targetCell.Column, targetCell.Column) * -1;
            for (int column = targetCell.Column; column > minLoopIteration; column--)
            {
                var fartherColumn = 2 * targetCell.Column - column;

                if (IsInBoundsOfParking(parking, column))
                {
                    if (parking[targetCell.Row][column] == 0)
                    {
                        parking[targetCell.Row][column] = 1;
                        counter += column;
                        break;
                    }
                    else if (IsInBoundsOfParking(parking, fartherColumn))
                    {
                        if (parking[targetCell.Row][fartherColumn] == 0)
                        {
                            parking[targetCell.Row][fartherColumn] = 1;
                            counter += fartherColumn;
                            break;
                        }
                    }
                }
                else if (IsInBoundsOfParking(parking, fartherColumn))
                {
                    if (parking[targetCell.Row][fartherColumn] == 0)
                    {
                        parking[targetCell.Row][fartherColumn] = 1;
                        counter += fartherColumn;
                        break;
                    }
                }
            }

            if (counter > 0)
            {
                counter += Math.Abs(entryRow - targetCell.Row) + 1;
            }

            return counter;
        }

        private static bool IsInBoundsOfParking(int[][] parking, int column)
        {
            var result = false;

            if (column < parking[0].Length && column > 0)
            {
                result = true;
            }

            return result;
        }

        private static void InitializeParking(int[][] parking, int columns)
        {
            for (int row = 0; row < parking.Length; row++)
            {
                parking[row] = new int[columns];
            }
        }
    }

    internal class Cell
    {
        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}