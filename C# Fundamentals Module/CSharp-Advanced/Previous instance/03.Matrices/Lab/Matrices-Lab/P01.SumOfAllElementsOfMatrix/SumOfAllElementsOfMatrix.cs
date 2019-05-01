namespace P01.SumOfAllElementsOfMatrix
{
    using System;
    using System.Linq;

    public class SumOfAllElementsOfMatrix
    {
        public static void Main(string[] args)
        {
            string[] inputParams = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var rowCount = int.Parse(inputParams[0]);
            var columnCount = int.Parse(inputParams[1]);

            var matrix = new int[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                var curentRowElements = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = curentRowElements;
            }

            int rows = matrix.Length;
            int columns = matrix[0].Length;

            int sum = matrix.Sum(r => r.Sum());

            Console.WriteLine(rows);
            Console.WriteLine(columns);
            Console.WriteLine(sum);
        }
    }
}
