namespace P06.FootballTeamGenerator.Models
{
    using System;
    using static Constants;

    internal class Player
    {
        private string name;
        private Stats stats;
        private double rating;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
            this.rating = CalculateRating();
        }

        public double Rating
        {
            get => this.rating;
        }
        
        public Stats Stats
        {
            get => this.stats;

            private set
            {
                this.stats = value;
            }
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

        private double CalculateRating()
        {
            var rating = ((double)this.stats.Endurance
                + this.stats.Dribble
                + this.stats.Passing
                + this.stats.Shooting
                + this.stats.Sprint) / 5;

            return rating;
        }
    }
}
