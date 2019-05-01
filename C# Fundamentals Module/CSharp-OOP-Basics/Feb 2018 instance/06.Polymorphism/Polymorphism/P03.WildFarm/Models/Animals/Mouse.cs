namespace P03.WildFarm.Models.Animals
{
    using Foods;
    using System;

    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            var foodType = food.GetType();

            if (foodType == typeof(Vegetable) || foodType == typeof(Fruit))
            {
                this.Weight += 0.1 * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidFeeding, this.GetType().Name, foodType.Name));
            }
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
