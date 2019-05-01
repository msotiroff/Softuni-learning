namespace P03.WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; private set; }

        public Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
