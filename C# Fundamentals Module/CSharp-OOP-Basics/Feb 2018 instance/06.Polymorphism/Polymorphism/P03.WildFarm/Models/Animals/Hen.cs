namespace P03.WildFarm.Models.Animals
{
    using Foods;

    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            var foodQty = food.Quantity;

            this.Weight += 0.35 * food.Quantity;
            this.FoodEaten += food.Quantity;
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
