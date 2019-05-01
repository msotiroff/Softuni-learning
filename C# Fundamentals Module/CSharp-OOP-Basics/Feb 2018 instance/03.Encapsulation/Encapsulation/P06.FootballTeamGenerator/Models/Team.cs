namespace P06.FootballTeamGenerator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static Constants;

    internal class Team
    {
        private string name;
        private IList<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(InvalidName);
                }

                this.name = value;
            }
        }

        public double Rating
        {
            get => this.CalculateRating();
        }

        private double CalculateRating()
        {
            return this.players.Any()
                ? this.players.Average(p => p.Rating)
                : 0;
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            var playerToBeRemoved = this.players.FirstOrDefault(p => p.Name == playerName);

            if (playerToBeRemoved == null)
            {
                throw new ArgumentException(string.Format(NoSuchAPlayerInTeam, playerName, this.name));
            }

            this.players.Remove(playerToBeRemoved);
        }
    }
}
