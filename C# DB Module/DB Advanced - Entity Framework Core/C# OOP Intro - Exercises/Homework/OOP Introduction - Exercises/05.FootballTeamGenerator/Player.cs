namespace _05.FootballTeamGenerator
{
    using System;

    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        private double overallSkillLevel;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
            this.OverallSkillLevel = overallSkillLevel;
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

        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                if (!ValidateData(value))
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }


        public int Passing
        {
            get { return this.passing; }
            private set
            {
                if (!ValidateData(value))
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }
                this.passing = value;
            }
        }

        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                if (!ValidateData(value))
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                }
                this.dribble = value;
            }
        }

        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                if (!ValidateData(value))
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                }
                this.sprint = value;
            }
        }


        public int Endurance
        {
            get { return this.endurance; }
            private set
            {
                if (!ValidateData(value))
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }
                this.endurance = value;
            }
        }

        public double OverallSkillLevel
        {
            get { return this.overallSkillLevel; }
            private set
            {
                double avgLevel = (double)(this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5;

                this.overallSkillLevel = avgLevel;
            }
        }

        private bool ValidateData(int value)
        {
            if (value < 0 || value > 100)
            {
                return false;
            }

            return true;
        }
    }
}
