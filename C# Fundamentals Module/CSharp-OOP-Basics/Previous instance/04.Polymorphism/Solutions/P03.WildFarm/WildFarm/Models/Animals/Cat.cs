namespace WildFarm.Models.Animals
{
    using Models.Foods;
    using Models.Animals.AbstractTypes;

    public class Cat : Felime
    {
        private string breed;

        public Cat(string animalName, double animalWeight, string animalLivingRegion, string breed)
            : base(animalName, animalWeight, animalLivingRegion)
        {
            this.Breed = breed;
        }

        public string Breed
        {
            get => this.breed;

            private set => this.breed = value;
        }

        public override void Eat(Food food)
        {
            this.FoodEaten += food.Quantity;
        }

        public override string MakeSound()
        {
            return "Meowwww";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{base.AnimalName}, {this.breed}, {base.AnimalWeight}, {this.LivingRegion}, {base.FoodEaten}]";
        }
    }
}
