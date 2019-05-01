using System;

namespace P15.DrawingTool.Models
{
    public class Square : Quadrangle
    {
        private int size;

        public Square(int size)
        {
            this.Size = size;
        }

        public int Size
        {
            get { return size; }
            private set { size = value; }
        }

        public override void DrawQuadrangle()
        {
            for (int rowIndex = 0; rowIndex < this.size; rowIndex++)
            {
                if (rowIndex == 0 || rowIndex == this.size - 1)
                {
                    Console.WriteLine($"|{new string('-', this.size)}|");
                }
                else
                {
                    Console.WriteLine($"|{new string(' ', this.size)}|");
                }
            }
        }
    }
}
