namespace P03.WildFarm.Models.Animals
{
    using Foods;
    using System;

    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            var foodType = food.GetType();

            if (foodType != typeof(Meat))
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidFeeding, this.GetType().Name, foodType.Name));
            }

            this.Weight += 1.0 * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
