namespace P05.PizzaCalories.Models
{
    using PizzaCalories.DataConstants;
    using System;
    using static DataConstants.Constants;

    internal class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        
        public int Weight
        {
            get => this.weight;

            private set
            {
                if (value < DoughMinWeight || value > DoughMaxWeight)
                {
                    throw new ArgumentException(string.Format(Messages.InvalidDoughWeight, DoughMinWeight, DoughMaxWeight));
                }

                this.weight = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if (!value.Equals("crispy", StringComparison.InvariantCultureIgnoreCase)
                    && !value.Equals("chewy", StringComparison.InvariantCultureIgnoreCase)
                    && !value.Equals("homemade", StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new ArgumentException(Messages.InvalidDoughType);
                }

                this.bakingTechnique = value;
            }
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (!value.Equals("white", StringComparison.InvariantCultureIgnoreCase) 
                    && !value.Equals("wholegrain", StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new ArgumentException(Messages.InvalidDoughType);
                }

                this.flourType = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = 2 * this.weight;

            double white = 1.5;
            double crispy = 0.9;
            double chewy = 1.1;

            if (this.flourType.Equals("white", StringComparison.InvariantCultureIgnoreCase))
            {
                calories *= white;
            }
            if (this.bakingTechnique.Equals("crispy", StringComparison.InvariantCultureIgnoreCase))
            {
                calories *= crispy;
            }
            if (this.bakingTechnique.Equals("chewy", StringComparison.InvariantCultureIgnoreCase))
            {
                calories *= chewy;
            }

            return calories;
        }
    }
}
