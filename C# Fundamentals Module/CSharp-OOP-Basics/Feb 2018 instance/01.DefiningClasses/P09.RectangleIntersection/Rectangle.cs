namespace P09.RectangleIntersection
{
    class Rectangle
    {
        public string Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double TopLeftX { get; set; }

        public double TopLeftY { get; set; }

        public Rectangle(string id, double width, double height, double xCoordinate, double yCoordinate) 
        {
            this.Id = id;
            this.Width = width;
            this.Height = height;
            this.TopLeftX = xCoordinate;
            this.TopLeftY = yCoordinate;
        }

        public bool IntersectWith(Rectangle rectangle)
        {
            return !(this.TopLeftX > rectangle.TopLeftX + rectangle.Width
                || this.TopLeftX + this.Width < rectangle.TopLeftX
                || this.TopLeftY > rectangle.TopLeftY + rectangle.Height
                || this.TopLeftY + this.Height < rectangle.TopLeftY);

        }
    }
}
