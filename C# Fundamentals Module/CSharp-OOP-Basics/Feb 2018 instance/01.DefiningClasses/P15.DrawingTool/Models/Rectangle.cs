using System;

namespace P15.DrawingTool.Models
{
    public class Rectangle : Quadrangle
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public int Height
        {
            get { return height; }
            private set { height = value; }
        }


        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public override void DrawQuadrangle()
        {
            for (int rowIndex = 0; rowIndex < this.height; rowIndex++)
            {
                if (rowIndex == 0 || rowIndex == this.height - 1)
                {
                    Console.WriteLine($"|{new string('-', this.width)}|");
                }
                else
                {
                    Console.WriteLine($"|{new string(' ', this.width)}|");
                }
            }
        }
    }
}
