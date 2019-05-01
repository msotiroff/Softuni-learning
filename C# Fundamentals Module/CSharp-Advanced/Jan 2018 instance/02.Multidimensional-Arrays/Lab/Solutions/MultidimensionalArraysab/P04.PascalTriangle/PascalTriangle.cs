namespace P04.PascalTriangle
{
    using System;

    class PascalTriangle
    {
        private static long[][] triangle;

        static void Main(string[] args)
        {
            var triangleHeight = int.Parse(Console.ReadLine());

            triangle = new long[triangleHeight][];

            triangle[0] = new long[] { 1 };

            for (int row = 1; row < triangleHeight; row++)
            {
                triangle[row] = new long[row + 1];

                for (int col = 0; col < triangle[row].Length; col++)
                {
                    var upperLeftElement = IsInBoundsOfTriangle(row - 1, col - 1) ? triangle[row - 1][col - 1] : 0;
                    var upperRightElement = IsInBoundsOfTriangle(row - 1, col) ? triangle[row - 1][col] : 0; ;
                    triangle[row][col] = upperLeftElement + upperRightElement;
                }
            }

            // Print triangle:
            foreach (var row in triangle)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static bool IsInBoundsOfTriangle(long row, long column)
        {
            return row >= 0
                && column >= 0
                && row < triangle.Length
                && column < triangle[row].Length;
        }
    }
}
