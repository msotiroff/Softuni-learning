namespace P02.JediGalaxy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        private static int rows;
        private static int columns;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rows = dimensions[0];
            columns = dimensions[1];

            var counter = 0;

            var matrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }
            
            var evilCells = new HashSet<string>();

            long ivoStarsSum = 0;

            string command;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                var ivosCoords = command.Split().Select(int.Parse).ToArray();
                var evilsCoords = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var ivoRow = ivosCoords.First();
                var ivoCol = ivosCoords.Last();

                var evilRow = evilsCoords.First();
                var evilCol = evilsCoords.Last();

                // Adds the evil affected cells to evilsCoords:
                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (IsInMatrix(evilRow, evilCol))
                    {
                        evilCells.Add($"{evilRow}->{evilCol}");
                    }

                    evilRow--;
                    evilCol--;
                }

                // Adds the ivo collected stars value:
                while (ivoRow >= 0 && ivoCol < columns)
                {
                    if (IsInMatrix(ivoRow, ivoCol))
                    {
                        var coordsToBeAdded = $"{ivoRow}->{ivoCol}";
                        if (!evilCells.Contains(coordsToBeAdded))
                        {
                            //ivoCells.Add(coordsToBeAdded);
                            ivoStarsSum += matrix[ivoRow, ivoCol];
                        }
                    }

                    ivoRow--;
                    ivoCol++;
                }
            }

            Console.WriteLine(ivoStarsSum);
        }

        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0
                && row < rows
                && col >= 0
                && col < columns;
        }
    }
}
