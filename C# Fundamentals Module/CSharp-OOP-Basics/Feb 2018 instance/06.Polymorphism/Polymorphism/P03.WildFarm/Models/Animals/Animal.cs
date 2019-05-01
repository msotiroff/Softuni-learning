using P03.WildFarm.Models.Foods;

namespace P03.WildFarm.Models.Animals
{
    public abstract class Animal
    {
        // string Name, double Weight, int FoodEaten;

        public string Name { get; private set; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; protected set; }

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public abstract string ProduceSound();

        public abstract void Eat(Food food);
    }
}
