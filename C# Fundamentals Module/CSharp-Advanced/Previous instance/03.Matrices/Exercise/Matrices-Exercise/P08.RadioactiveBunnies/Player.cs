namespace P08.RadioactiveBunnies
{
    internal class Player
    {
        public Player(Point position)
        {
            this.IsAlive = true;
            this.IsWinner = false;
            this.Position = position;
        }

        public bool IsAlive { get; set; }

        public bool IsWinner { get; set; }

        public Point Position { get; set; }
    }
}
