namespace P06.FootballTeamGenerator.Models
{
    using System;
    using static Constants;

    internal class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        
        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        internal int Endurance
        {
            get => this.endurance;

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(InvalidStats, nameof(Endurance)));
                }

                this.endurance = value;
            }
        }

        internal int Sprint
        {
            get => this.sprint;

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(InvalidStats, nameof(Sprint)));
                }

                this.sprint = value;
            }
        }

        internal int Dribble
        {
            get => this.dribble;

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(InvalidStats, nameof(Dribble)));
                }

                this.dribble = value;
            }
        }
        
        internal int Passing
        {
            get => this.passing;

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(InvalidStats, nameof(Passing)));
                }

                this.passing = value;
            }
        }

        internal int Shooting
        {
            get => this.shooting;

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(string.Format(InvalidStats, nameof(Shooting)));
                }

                this.shooting = value;
            }
        }
    }
}
