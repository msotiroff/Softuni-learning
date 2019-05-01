namespace P09.RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
              var rectanglesArgs = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var allRectangles = new List<Rectangle>();

            var rectanglesCount = rectanglesArgs[0];
            var intersectionChecks = rectanglesArgs[1];

            for (int i = 0; i < rectanglesCount; i++)
            {
                var rectangleParams = Console.ReadLine().Split();

                var id = rectangleParams[0];
                var width = double.Parse(rectangleParams[1]);
                var height = double.Parse(rectangleParams[2]);
                var topLeftX = double.Parse(rectangleParams[3]);
                var topLeftY = double.Parse(rectangleParams[4]);


                var rectangle = new Rectangle(id, width, height, topLeftX, topLeftY);
                allRectangles.Add(rectangle);
            }

            for (int j = 0; j < intersectionChecks; j++)
            {
                var rectanglesToBeChecked = Console.ReadLine().Split();

                var firstRectange = allRectangles.FirstOrDefault(r => r.Id == rectanglesToBeChecked.First());
                var secondRectangle = allRectangles.FirstOrDefault(r => r.Id == rectanglesToBeChecked.Last());

                Console.WriteLine(firstRectange.IntersectWith(secondRectangle).ToString().ToLower());
            }
        }
    }
}
