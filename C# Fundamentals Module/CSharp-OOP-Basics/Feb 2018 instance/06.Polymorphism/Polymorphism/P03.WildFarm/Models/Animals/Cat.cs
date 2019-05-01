namespace P03.WildFarm.Models.Animals
{
    using Foods;
    using System;

    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            var foodType = food.GetType();

            if (foodType == typeof(Vegetable) || foodType == typeof(Meat))
            {
                this.Weight += 0.3 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidFeeding, this.GetType().Name, foodType.Name));
            }
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
