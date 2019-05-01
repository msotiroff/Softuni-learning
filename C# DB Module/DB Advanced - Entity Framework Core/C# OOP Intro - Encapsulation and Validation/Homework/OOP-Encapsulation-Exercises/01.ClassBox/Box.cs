class Box
{
    private double lenght;
    private double width;
    private double height;

    public Box(double lenght, double width, double height)
    {
        this.lenght = lenght;
        this.width = width;
        this.height = height;
    }
    public double GetSurface()
    {
        double surface = 2 * (this.lenght * this.height + this.lenght * this.width + this.width * this.height);

        return surface;
    }

    public double GetLateralSurfaceArea()
    {
        double lateralSurfaceArea = 2 * (this.lenght * this.height + this.width * this.height);

        return lateralSurfaceArea;
    }

    public double GetVolume()
    {
        double volume = this.width * this.height * this.lenght;

        return volume;
    }
}

