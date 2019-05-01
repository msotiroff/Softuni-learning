using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Rectangle_Position
{
    class RectanglePosition
    {
        static void Main(string[] args)
        {
            int[] firstRectangleProps = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int[] secondRectangleProps = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            Rectangle firstRect = new Rectangle();
            firstRect.Left = firstRectangleProps[0];
            firstRect.Top = firstRectangleProps[1];
            firstRect.Width = firstRectangleProps[2];
            firstRect.Height = firstRectangleProps[3];
            firstRect.Right = GetRightPoint(firstRect.Left, firstRect.Width);
            firstRect.Bottom = GetBottomPoint(firstRect.Top, firstRect.Height);

            Rectangle secondRect = new Rectangle();
            secondRect.Left = secondRectangleProps[0];
            secondRect.Top = secondRectangleProps[1];
            secondRect.Width = secondRectangleProps[2];
            secondRect.Height = secondRectangleProps[3];
            secondRect.Right = GetRightPoint(secondRect.Left, secondRect.Width);
            secondRect.Bottom = GetBottomPoint(secondRect.Top, secondRect.Height);


            Console.WriteLine(IsInside(firstRect, secondRect) ? "Inside" : "Not Inside");
        }
        public static bool IsInside(Rectangle first, Rectangle second)
        {
            bool isInside = false;
            if (first.Left >= second.Left && first.Right <= second.Right && 
                first.Top <= second.Top && first.Bottom <= second.Bottom)
            {
                isInside = true;
            }
            return isInside;
        }
        public static int GetBottomPoint(int top, int height)
        {
            int bottomPoint = top + height;
            return bottomPoint;
        }

        public static int GetRightPoint(int leftPoint, int width)
        {
            int rightPoint = leftPoint + width;
            return rightPoint;
        }
    }
}
