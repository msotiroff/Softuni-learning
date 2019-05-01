namespace P10.TheHeiganDance
{
    internal class Player
    {
        public Player(int health, Point position)
        {
            this.Health = health;
            this.Position = position;
            this.HasCloud = false;
        }

        public int Health { get; set; }

        public Point Position { get; set; }

        public string LastSpell { get; set; }

        public bool HasCloud { get; set; }
    }
}
