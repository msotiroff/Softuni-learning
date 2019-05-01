namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class StartUp
    {
        private static int[,] matrix;
        private static int rowsCount;
        private static int columnsCount;
        private static long starsCollected;

        public static void Main()
        {
            GetMatrixSizes();

            InitializeMatrix();

            CollectStars();

            PrintResult();
        }

        private static void PrintResult()
        {
            Console.WriteLine(starsCollected);
        }

        private static void GetMatrixSizes()
        {
            int[] dimestions = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            rowsCount = dimestions[0];
            columnsCount = dimestions[1];
        }

        private static void CollectStars()
        {
            string command; ;
            starsCollected = 0;

            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                int[] ivoArgs = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int ivoRow = ivoArgs[0];
                int ivoCol = ivoArgs[1];

                int[] evilArgs = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int evilRow = evilArgs[0];
                int evilCol = evilArgs[1];

                while (evilRow >= 0 && evilCol >= 0)
                {
                    if (evilRow >= 0 && evilRow < rowsCount && evilCol >= 0 && evilCol < columnsCount)
                    {
                        matrix[evilRow, evilCol] = 0;
                    }
                    evilRow--;
                    evilCol--;
                }

                while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
                {
                    if (ivoRow >= 0 && ivoRow < rowsCount && ivoCol >= 0 && ivoCol < columnsCount)
                    {
                        starsCollected += matrix[ivoRow, ivoCol];
                    }

                    ivoCol++;
                    ivoRow--;
                }
            }
        }

        private static void InitializeMatrix()
        {
            matrix = new int[rowsCount, columnsCount];

            int counter = 0;

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < columnsCount; j++)
                {
                    matrix[i, j] = counter++;
                }
            }
        }
    }
}
