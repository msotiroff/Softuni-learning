namespace P03.WildFarm.Models.Animals
{
    using Foods;
    using System;

    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            var foodType = food.GetType();

            if (foodType != typeof(Meat))
            {
                throw new InvalidOperationException(string.Format(Constants.InvalidFeeding, this.GetType().Name, foodType.Name));
            }

            this.Weight += 0.4 * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
