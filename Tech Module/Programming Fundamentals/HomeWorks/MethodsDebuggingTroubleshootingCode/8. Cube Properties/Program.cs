using System;

namespace _8.Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double cubeSide = double.Parse(Console.ReadLine());
            string property = Console.ReadLine();

            double cubeVolume = cubeSide * cubeSide * cubeSide;
            double cubeArea = 6 * cubeSide * cubeSide;

            double faceDiagonal = Math.Sqrt(cubeSide * cubeSide + cubeSide * cubeSide);
            double spaceDiagonal = Math.Sqrt(faceDiagonal * faceDiagonal + cubeSide * cubeSide);

            switch (property)
            {
                case "face": Console.WriteLine($"{faceDiagonal:f2}");
                    break;
                case "space": Console.WriteLine($"{spaceDiagonal:f2}");
                    break;
                case "volume": Console.WriteLine($"{cubeVolume:f2}");
                    break;
                case "area": Console.WriteLine($"{cubeArea:f2}");
                    break;
                default:
                    break;
            }

        }
    }
}
