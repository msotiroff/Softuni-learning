using System;

namespace P01.ClassBox
{
    public class Box
    {
        // length, width and height

        public double Length { get;  }
        public double Width { get;  }
        public double Height { get;  }

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
