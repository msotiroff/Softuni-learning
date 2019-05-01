namespace P02.CubicsRube
{
    using System;
    using System.Linq;

    public class CubicsRube
    {
        private static int cubeSize;

        public static void Main(string[] args)
        {
            cubeSize = int.Parse(Console.ReadLine());

            int unchangedCells = cubeSize * cubeSize * cubeSize;
            long sum = 0;

            string inputLine;
            while ((inputLine = Console.ReadLine()) != "Analyze")
            {
                var inputParams = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var firstDimenssion = inputParams[0];
                var secondDimenssion = inputParams[1];
                var thirdDimenssion = inputParams[2];
                var numberToAdd = inputParams[3];

                if (IsInCube(firstDimenssion, secondDimenssion, thirdDimenssion))
                {
                    if (numberToAdd != 0)
                    {
                        sum += numberToAdd;
                        unchangedCells--;
                    }
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(unchangedCells);
        }

        private static bool IsInCube(int firstDimenssion, int secondDimenssion, int thirdDimenssion)
        {
            return firstDimenssion >= 0
                && firstDimenssion < cubeSize
                && secondDimenssion >= 0
                && secondDimenssion < cubeSize
                && thirdDimenssion >= 0
                && thirdDimenssion < cubeSize;
        }
    }
}
