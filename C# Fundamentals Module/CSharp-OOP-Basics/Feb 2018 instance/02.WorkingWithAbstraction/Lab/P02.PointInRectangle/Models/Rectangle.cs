namespace P02.PointInRectangle.Models
{
    public class Rectangle
    {
        public Point TopLeftPoint { get; set; }
        public Point BottomRightPoint { get; set; }

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeftPoint = topLeft;
            this.BottomRightPoint = bottomRight;
        }

        public bool Contains (Point point)
        {
            return point.xAxis >= this.TopLeftPoint.xAxis
                && point.xAxis <= this.BottomRightPoint.xAxis
                && point.yAxis >= this.TopLeftPoint.yAxis
                && point.yAxis <= this.BottomRightPoint.yAxis;
        }
    }
}
