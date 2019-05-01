namespace P04.ChampionsLeague
{
    using System.Collections.Generic;

    internal class TeamInfo
    {
        public TeamInfo()
        {
            this.Wins = 0;
            this.Opponents = new HashSet<string>();
        }

        public int Wins { get; set; }
        public HashSet<string> Opponents { get; set; }
    }
}