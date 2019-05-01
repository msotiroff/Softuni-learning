namespace P07.LegoBlocks
{
    using System;
    using System.Linq;

    class LegoBlocks
    {
        static void Main(string[] args)
        {
            var countOfRows = int.Parse(Console.ReadLine());

            var firstMatrix = new int[countOfRows][];
            var secondMatrix = new int[countOfRows][];

            var isPerfectlyFitted = true;

            var count = 0;

            for (int i = 0; i < countOfRows; i++)
            {
                firstMatrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                count += firstMatrix[i].Length;
            }

            for (int i = 0; i < countOfRows; i++)
            {
                secondMatrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                count += secondMatrix[i].Length;
            }

            var rowLength = firstMatrix[0].Length + secondMatrix[0].Length;

            for (int i = 1; i < countOfRows; i++)
            {
                if (firstMatrix[i].Length + secondMatrix[i].Length != rowLength)
                {
                    isPerfectlyFitted = false;
                    break;
                }
            }

            if (!isPerfectlyFitted)
            {
                Console.WriteLine($"The total number of cells is: {count}");
            }
            else
            {
                for (int row = 0; row < countOfRows; row++)
                {
                    var wholeRow = firstMatrix[row].ToList();
                    wholeRow.AddRange(secondMatrix[row].Reverse());
                    Console.WriteLine($"[{string.Join(", ", wholeRow)}]");
                }
            }
        }
    }
}
