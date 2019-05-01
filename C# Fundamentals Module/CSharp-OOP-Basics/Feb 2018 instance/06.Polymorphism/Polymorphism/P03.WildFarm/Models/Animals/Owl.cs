namespace P03.WildFarm.Models.Animals
{
    using Foods;
    using System;

    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            var foodType = food.GetType();

            if (foodType != typeof(Meat))
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidFeeding, this.GetType().Name, foodType.Name));
            }

            this.Weight += 0.25 * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
