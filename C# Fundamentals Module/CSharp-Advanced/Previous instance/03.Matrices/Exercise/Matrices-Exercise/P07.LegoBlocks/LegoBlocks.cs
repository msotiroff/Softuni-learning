namespace P07.LegoBlocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LegoBlocks
    {
        public static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            var firstMatrix = new int[numberOfRows][];
            var secondMatrix = new int[numberOfRows][];

            FillMatrixes(firstMatrix, secondMatrix);

            if (!CanBePerfectlyFitted(firstMatrix, secondMatrix))
            {
                var cellsCount = firstMatrix.Sum(r => r.Length) + secondMatrix.Sum(r => r.Length);

                Console.WriteLine($"The total number of cells is: {cellsCount}");
            }
            else
            {
                var newMatrix = new int[numberOfRows][];

                for (int row = 0; row < numberOfRows; row++)
                {
                    var currentRow = new List<int>();
                    currentRow.AddRange(firstMatrix[row]);
                    currentRow.AddRange(secondMatrix[row].Reverse());

                    newMatrix[row] = currentRow.ToArray();
                }

                PrintMatrix(newMatrix);
            }
        }

        private static void PrintMatrix(int[][] matrix)
        {
            foreach (var row in matrix)
            {
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }
        }

        private static bool CanBePerfectlyFitted(int[][] firstMatrix, int[][] secondMatrix)
        {
            var result = true;

            var neededLength = firstMatrix[0].Length + secondMatrix[0].Length;

            for (int row = 1; row < firstMatrix.Length; row++)
            {
                var totalLength = firstMatrix[row].Length + secondMatrix[row].Length;

                if (totalLength != neededLength)
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        private static void FillMatrixes(int[][] firstMatrix, int[][] secondMatrix)
        {
            for (int row = 0; row < firstMatrix.Length; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                firstMatrix[row] = currentRow;
            }

            for (int row = 0; row < secondMatrix.Length; row++)
            {
                var currentRow = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                secondMatrix[row] = currentRow;
            }
        }
    }
}
