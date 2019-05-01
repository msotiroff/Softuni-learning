using System;

namespace ClassBox
{
    internal class Box
    {
        // length, width and height

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double length;

        private double width;

        private double height;

        public double Length
        {
            get => this.length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Length)} cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public double Width
        {
            get => this.width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Width)} cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get => this.height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"{nameof(Height)} cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        internal double GetSurface()
        {
            // Surface Area = 2lw + 2lh + 2wh

            return 2 * (this.length * this.width + this.length * this.height + this.width * this.height);
        }

        internal double GetLiteralSurface()
        {
            // Lateral Surface Area = 2lh + 2wh

            return 2 * (this.length * this.height + this.width * this.height);
        }

        internal double GetVolume()
        {
            //Volume = lwh

            return this.length * this.width * this.height;
        }
    }
}