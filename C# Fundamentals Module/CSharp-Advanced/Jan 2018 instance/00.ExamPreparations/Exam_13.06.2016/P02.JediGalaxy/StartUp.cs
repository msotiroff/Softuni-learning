namespace P02.JediGalaxy
{
    using System;
    using System.Linq;

    class StartUp
    {
        private static int rowsCount;
        private static int columnsCount;
        private static int[,] galaxy;

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            rowsCount = dimensions[0];
            columnsCount = dimensions[1];
            galaxy = new int[rowsCount, columnsCount];

            long collectedStars = 0;

            var counter = 0;

            for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                for (int colIndex = 0; colIndex < columnsCount; colIndex++)
                {
                    galaxy[rowIndex, colIndex] = counter;
                    counter++;
                }
            }

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Let the Force be with you")
            {
                var ivoCoords = inputLine.Split().Select(int.Parse).ToArray();
                var evilCoords = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var ivoRow = ivoCoords[0];
                var ivoCol = ivoCoords[1];
                var evilRow = evilCoords[0];
                var evilCol = evilCoords[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (IsInTheGalaxy(evilRow, evilCol))
                    {
                        galaxy[evilRow, evilCol] = 0;
                    }

                    evilRow--;
                    evilCol--;
                }

                while (ivoRow >= 0 && ivoCol < columnsCount)
                {
                    if (IsInTheGalaxy(ivoRow, ivoCol))
                    {
                        collectedStars += galaxy[ivoRow, ivoCol];
                    }

                    ivoRow--;
                    ivoCol++;
                }
            }

            Console.WriteLine(collectedStars);
        }

        private static bool IsInTheGalaxy(int row, int column)
        {
            return row >= 0
                && row < rowsCount
                && column >= 0
                && column < columnsCount;
        }
    }
}
