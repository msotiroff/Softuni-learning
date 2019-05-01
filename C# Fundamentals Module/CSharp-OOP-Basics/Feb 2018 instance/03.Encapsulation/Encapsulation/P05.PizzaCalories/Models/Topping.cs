namespace P05.PizzaCalories.Models
{
    using PizzaCalories.DataConstants;
    using System;
    using System.Linq;
    using static DataConstants.Constants;

    internal class Topping
    {
        private string[] validTypes = { "meat", "veggies", "cheese", "sauce" };
        private string type;
        private int weight;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public int Weight
        {
            get => this.weight;

            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(Messages.InvalidToppingWeight, 
                        this.type, 
                        ToppingMinWeight, 
                        ToppingMaxWeight));
                }

                this.weight = value;
            }
        }

        public string Type
        {
            get => this.type;

            private set
            {
                if (!this.validTypes.Contains(value.ToLower()))
                {
                    throw new ArgumentException(string.Format(Messages.InvalidToppingType, value));
                }

                this.type = value;
            }
        }

        public double CalculateCalories()
        {
            double calories = 2 * this.weight;

            double meat = 1.2;
            double veggies = 0.8;
            double cheese = 1.1;
            double sauce = 0.9;

            switch (this.type.ToLower())
            {
                case "meat":
                    calories *= meat;
                    break;
                case "veggies":
                    calories *= veggies;
                    break;
                case "cheese":
                    calories *= cheese;
                    break;
                case "sauce":
                    calories *= sauce;
                    break;
                default:
                    break;
            }

            return calories;
        }
    }
}
