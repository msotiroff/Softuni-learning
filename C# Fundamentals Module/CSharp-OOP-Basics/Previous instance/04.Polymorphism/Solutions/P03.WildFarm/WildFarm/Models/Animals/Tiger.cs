namespace WildFarm.Models.Animals
{
    using Models.Foods;
    using System;
    using Models.Animals.AbstractTypes;

    public class Tiger : Mammal
    {
        public Tiger(string animalName, double animalWeight, string animalLivingRegion) 
            : base(animalName, animalWeight, animalLivingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != nameof(Meat))
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
            }

            this.FoodEaten += food.Quantity;
        }

        public override string MakeSound()
        {
            return "ROAAR!!!";
        }
    }
}
