using System;

class Box
{
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double Length
    {
        get { return this.length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }

            this.length = value;
        }
    }
    public double Width
    {
        get { return this.width; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }

            this.width = value;
        }
    }
    public double Height
    {
        get { return this.height; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }

            this.height = value;
        }
    }

    public double GetSurface()
    {
        double surface = 2 * (this.length * this.height + this.length * this.width + this.width * this.height);

        return surface;
    }

    public double GetLateralSurfaceArea()
    {
        double lateralSurfaceArea = 2 * (this.length * this.height + this.width * this.height);

        return lateralSurfaceArea;
    }

    public double GetVolume()
    {
        double volume = this.width * this.height * this.length;

        return volume;
    }
}

