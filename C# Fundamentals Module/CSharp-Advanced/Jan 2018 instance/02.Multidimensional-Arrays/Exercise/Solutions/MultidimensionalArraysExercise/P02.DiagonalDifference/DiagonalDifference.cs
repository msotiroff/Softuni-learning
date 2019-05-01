namespace P02.DiagonalDifference
{
    using System;
    using System.Linq;

    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());

            var square = new int[dimensions][];

            for (int i = 0; i < dimensions; i++)
            {
                square[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            var leftDiagonalSum = 0;
            for (int i = 0; i < square.Length; i++)
            {
                leftDiagonalSum += square[i][i];
            }

            var rightDiagonalSum = 0;

            for (int row = 0; row < square.Length; row++)
            {
                var col = square[row].Length - 1 - row;
                rightDiagonalSum += square[row][col];
            }

            Console.WriteLine(Math.Abs(leftDiagonalSum - rightDiagonalSum));
        }
    }
}
