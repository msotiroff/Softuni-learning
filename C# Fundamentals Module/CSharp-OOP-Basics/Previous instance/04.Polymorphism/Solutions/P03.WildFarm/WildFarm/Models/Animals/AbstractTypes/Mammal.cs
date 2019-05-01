namespace WildFarm.Models.Animals.AbstractTypes
{
    using System;
    using WildFarm.Models.Foods;

    public abstract class Mammal : Animal
    {
        string livingRegion;

        protected Mammal(string animalName, double animalWeight, string animalLivingRegion)
        {
            base.AnimalName = animalName;
            base.AnimalWeight = animalWeight;
            base.AnimalType = this.GetType().Name;
            this.LivingRegion = animalLivingRegion;
        }

        protected string LivingRegion
        {
            get => this.livingRegion;

            private set => this.livingRegion = value;
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name != nameof(Vegetable))
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{base.AnimalName}, {base.AnimalWeight}, {this.livingRegion}, {base.FoodEaten}]";            
        }
    }
}
