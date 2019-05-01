using System;

namespace P02.ClassBoxDataValidation
{
    public class Box
    {
        private const string errorMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(errorMessage, nameof(this.Height)));
                }

                this.height = value;
            }
        }


        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(errorMessage, nameof(this.Width)));
                }

                this.width = value;
            }
        }


        public double Length
        {
            get { return length; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(errorMessage, nameof(this.Length)));
                }

                this.length = value;
            }
        }



        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double GetVolume()
        {
            // Volume = lwh

            var volume = this.Length * this.Width * this.Height;

            return volume;
        }

        private double GetLateralSurfaceArea()
        {
            // Lateral Surface Area = 2lh + 2wh

            double result = 2 * (this.Length * this.Height + this.Width * this.Height);

            return result;
        }

        private double GetSurfaceArea()
        {
            // Surface Area = 2lw + 2lh + 2wh

            double result = 2 * (this.Length * this.Width + this.Length * this.Height + this.Width * this.Height);

            return result;
        }

        public override string ToString()
        {
            var result = $"Surface Area - {this.GetSurfaceArea():f2}{Environment.NewLine}"
                + $"Lateral Surface Area - {this.GetLateralSurfaceArea():f2}{Environment.NewLine}"
                + $"Volume - {this.GetVolume():f2}";

            return result;
        }
    }
}
