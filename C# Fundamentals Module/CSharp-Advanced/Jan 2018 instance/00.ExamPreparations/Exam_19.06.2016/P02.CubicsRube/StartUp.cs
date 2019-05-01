namespace P02.CubicsRube
{
    using System;

    class StartUp
    {
        private static int cubeSizes;

        static void Main(string[] args)
        {
            cubeSizes = int.Parse(Console.ReadLine());

            var undamagedCells = Math.Pow(cubeSizes, 3);

            long sum = 0;

            string input;
            while ((input = Console.ReadLine()) != "Analyze")
            {
                var inputParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var dimensionX = int.Parse(inputParams[0]);
                var dimensionY = int.Parse(inputParams[1]);
                var dimensionZ = int.Parse(inputParams[2]);

                var damage = long.Parse(inputParams[3]);

                if (IsInCube(dimensionX, dimensionY, dimensionZ) && damage != 0)
                {
                    undamagedCells--;
                    sum += damage;
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(undamagedCells >= 0 ? undamagedCells : 0);
        }

        private static bool IsInCube(int dimensionX, int dimensionY, int dimensionZ)
        {
            return dimensionX >= 0
                && dimensionX < cubeSizes
                && dimensionY >= 0
                && dimensionY < cubeSizes
                && dimensionZ >= 0
                && dimensionZ < cubeSizes;
        }
    }
}
