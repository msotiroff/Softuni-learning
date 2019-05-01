namespace P02.PointInRectangle
{
    using P02.PointInRectangle.Models;
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            // <topLeftX> <topLeftY> <bottomRightX> <bottomRightY>

            var rectPoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var topLeftX = rectPoints[0];
            var topLeftY = rectPoints[1];
            var botRightX = rectPoints[2];
            var botRightY = rectPoints[3];

            var topLeftPoint = CreatePoint(topLeftX, topLeftY);
            var bottomRightPoint = CreatePoint(botRightX, botRightY);
            
            var rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            var checksCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < checksCount; i++)
            {
                var currentPointParams = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var point = CreatePoint(currentPointParams);

                Console.WriteLine(rectangle.Contains(point));
            }
        }

        public static Point CreatePoint(params int[] coordinates)
        {
            var x = coordinates[0];
            var y = coordinates[1];

            return new Point(x, y);
        }
    }
}
