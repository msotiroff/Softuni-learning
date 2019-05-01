using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Portal
{
    public class Point
    {
        public int HorisontalIndex { get; set; }
        public int VerticalIndex { get; set; }
    }

    public class Portal
    {
        public static void Main(string[] args)
        {
            int rowsInMatrix = int.Parse(Console.ReadLine());

            List<List<char>> matrix = new List<List<char>>();

            ReadMatrix(rowsInMatrix, matrix);

            Point currentPoint = new Point();

            FindStartPoint(matrix, currentPoint);

            int matrixRows = rowsInMatrix;
            int matrixColumns = matrix[0].Count;

            bool exitFound = false;
            int turns = 0;
            string commands = Console.ReadLine();

            for (int i = 0; i < commands.Length; i++)
            {
                char currentCommand = commands[i];
                turns++;

                if (currentCommand == 'D')
                {
                    TurnDown(matrix, currentPoint, matrixRows);

                    if (matrix[currentPoint.VerticalIndex][currentPoint.HorisontalIndex] == 'E')
                    {
                        exitFound = true;
                    }
                }
                else if (currentCommand == 'U')
                {
                    TurnUp(matrix, currentPoint, matrixRows);

                    if (matrix[currentPoint.VerticalIndex][currentPoint.HorisontalIndex] == 'E')
                    {
                        exitFound = true;
                    }
                }
                else if (currentCommand == 'L')
                {
                    TurnLeft(matrix, currentPoint, matrixColumns);

                    if (matrix[currentPoint.VerticalIndex][currentPoint.HorisontalIndex] == 'E')
                    {
                        exitFound = true;
                    }
                }
                else if (currentCommand == 'R')
                {
                    TurnRight(matrix, currentPoint, matrixColumns);

                    if (matrix[currentPoint.VerticalIndex][currentPoint.HorisontalIndex] == 'E')
                    {
                        exitFound = true;
                    }
                }

                if (exitFound)
                {
                    break;
                }
            }

            if (! exitFound)
            {
                Console.WriteLine($"Robot stuck at {currentPoint.VerticalIndex} {currentPoint.HorisontalIndex}. Experiment failed.");
            }
            else
            {
                Console.WriteLine($"Experiment successful. {turns} turns required.");
            }


        }

        public static void TurnRight(List<List<char>> matrix, Point currentPoint, int matrixColumns)
        {
            currentPoint.HorisontalIndex++;
            currentPoint.HorisontalIndex %= matrixColumns;

            while (matrix[currentPoint.VerticalIndex][currentPoint.HorisontalIndex] == 'N')
            {
                currentPoint.HorisontalIndex++;
                currentPoint.HorisontalIndex %= matrixColumns;
            }
        }

        public static void TurnLeft(List<List<char>> matrix, Point currentPoint, int matrixColumns)
        {
            currentPoint.HorisontalIndex--;
            if (currentPoint.HorisontalIndex < 0)
            {
                currentPoint.HorisontalIndex = matrixColumns - 1;
            }

            while (matrix[currentPoint.VerticalIndex][currentPoint.HorisontalIndex] == 'N')
            {
                currentPoint.HorisontalIndex--;
                if (currentPoint.HorisontalIndex < 0)
                {
                    currentPoint.HorisontalIndex = matrixColumns - 1;
                }

            }
        }

        public static void TurnUp(List<List<char>> matrix, Point currentPoint, int matrixRows)
        {
            currentPoint.VerticalIndex--;
            if (currentPoint.VerticalIndex < 0)
            {
                currentPoint.VerticalIndex = matrixRows - 1;
            }

            while (matrix[currentPoint.VerticalIndex][currentPoint.HorisontalIndex] == 'N')
            {
                currentPoint.VerticalIndex--;
                if (currentPoint.VerticalIndex < 0)
                {
                    currentPoint.VerticalIndex = matrixRows - 1;
                }
            }
        }

        public static void TurnDown(List<List<char>> matrix, Point currentPoint, int matrixRows)
        {
            currentPoint.VerticalIndex++;
            currentPoint.VerticalIndex %= matrixRows;

            while (matrix[currentPoint.VerticalIndex][currentPoint.HorisontalIndex] == 'N')
            {
                currentPoint.VerticalIndex++;
                currentPoint.VerticalIndex %= matrixRows;
            }
        }

        public static void FindStartPoint(List<List<char>> matrix, Point currentPoint)
        {
            for (int col = 0; col < matrix.Count; col++)
            {
                for (int row = 0; row < matrix[col].Count; row++)
                {
                    if (matrix[col][row] == 'S')
                    {
                        currentPoint.HorisontalIndex = row;
                        currentPoint.VerticalIndex = col;
                        break;
                    }
                }
            }
        }

        public static void ReadMatrix(int rowsInMatrix, List<List<char>> matrix)
        {
            for (int i = 0; i < rowsInMatrix; i++)
            {
                var currentRow = Console.ReadLine().ToCharArray().ToList();
                matrix.Add(currentRow);
            }

            int longestRowCount = 0;
            for (int i = 0; i < matrix.Count; i++)
            {
                var currRow = matrix[i];
                int currentLenght = currRow.Count;
                if (longestRowCount < currentLenght)
                {
                    longestRowCount = currentLenght;
                }
            }

            for (int i = 0; i < matrix.Count; i++)
            {
                var currentRow = matrix[i];
                for (int j = currentRow.Count; j < longestRowCount; j++)
                {
                    matrix[i].Add('N');
                }
            }
        }
    }
}
