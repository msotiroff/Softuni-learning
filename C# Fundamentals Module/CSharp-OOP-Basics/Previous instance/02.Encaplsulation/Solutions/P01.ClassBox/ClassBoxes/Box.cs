internal class Box
{
    // length, width and height

    public Box(double length, double width, double height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    private double length;

    private double width;

    private double height;

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