namespace P03.KnightsTour
{
    public class Cell
    {
        public Cell(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            this.IsVisited = false;
            this.TurnVisited = 0;
        }

        public int Row { get; private set; }

        public int Column { get; private set; }

        public bool IsVisited { get; set; }

        public int TurnVisited { get; set; }
    }
}
