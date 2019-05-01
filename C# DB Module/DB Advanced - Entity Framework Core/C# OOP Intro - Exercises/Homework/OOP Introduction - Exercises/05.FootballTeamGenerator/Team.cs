namespace _05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public double Rating
        {
            get { return this.GetRating(); }
        }

        public List<Player> Players
        {
            get { return this.players; }
        }
        
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }
        
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            this.players.Remove(player);
        }

        private double GetRating()
        {
            if (this.players.Count() > 0)
            {
                return this.players.Average(p => p.OverallSkillLevel);
            }

            return 0;
        }
    }
}
