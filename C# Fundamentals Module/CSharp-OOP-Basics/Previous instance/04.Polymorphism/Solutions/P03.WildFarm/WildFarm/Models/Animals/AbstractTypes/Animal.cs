namespace WildFarm.Models.Animals.AbstractTypes
{
    using Models.Foods;

    public abstract class Animal
    {
        string animalName;
        string animalType;
        double animalWeight;
        int foodEaten;

        public virtual int FoodEaten
        {
            get => this.foodEaten;

            protected set => this.foodEaten = value;
        }

        public double AnimalWeight
        {
            get => this.animalWeight;

            protected set => this.animalWeight = value;
        }

        public string AnimalType
        {
            get => this.animalType;

            protected set => this.animalType = value;
        }

        public string AnimalName
        {
            get => this.animalName;

            protected set => this.animalName = value;
        }

        public abstract string MakeSound();

        public abstract void Eat(Food food);
    }
}
