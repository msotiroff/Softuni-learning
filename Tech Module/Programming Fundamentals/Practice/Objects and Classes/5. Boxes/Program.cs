using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Boxes
{
    public class Boxes
    {
        public static void Main(string[] args)
        {
            string inputLine = Console.ReadLine();

            List<Box> allBoxes = new List<Box>();

            while (inputLine != "end")
            {
                string[] pointsCoordinates = inputLine
                    .Split(new[] {' ', '|'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                List<int> eachPointCoords = new List<int>();
                for (int i = 0; i < pointsCoordinates.Length; i++)
                {
                    string[] currentCoordinate = pointsCoordinates[i].Split(':').ToArray();
                    eachPointCoords.Add(int.Parse(currentCoordinate[0]));
                    eachPointCoords.Add(int.Parse(currentCoordinate[1]));
                }
                Box currentBox = new Box
                {
                    UpperLeftPoint = new Point { X = eachPointCoords[0], Y = eachPointCoords[1] },
                    UpperRightPoint = new Point { X = eachPointCoords[2], Y = eachPointCoords[3] },
                    BottomLeftPoint = new Point { X = eachPointCoords[4], Y = eachPointCoords[5] },
                    BottomRightPoint = new Point { X = eachPointCoords[6], Y = eachPointCoords[7] }
                };
                currentBox.SideA = Point.CalculateDistance(currentBox.UpperLeftPoint, currentBox.UpperRightPoint);
                currentBox.SideB = Point.CalculateDistance(currentBox.UpperLeftPoint, currentBox.BottomLeftPoint);
                currentBox.Perimeter = Box.CalculatePerimeter(currentBox.SideA, currentBox.SideB);
                currentBox.Area = Box.CalculateArea(currentBox.SideA, currentBox.SideB);

                allBoxes.Add(currentBox);

                inputLine = Console.ReadLine();
            }

            foreach (var box in allBoxes)
            {
                Console.WriteLine($"Box: {box.SideA}, {box.SideB}");
                Console.WriteLine($"Perimeter: {box.Perimeter}");
                Console.WriteLine($"Area: {box.Area}");
            }
        }
        
    }
}
