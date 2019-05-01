namespace P02.PointInRectangle.Models
{
    public class Point
    {
        public int xAxis { get; set; }
        public int yAxis { get; set; }

        public Point (int x, int y)
        {
            this.xAxis = x;
            this.yAxis = y;
        }
    }
}
