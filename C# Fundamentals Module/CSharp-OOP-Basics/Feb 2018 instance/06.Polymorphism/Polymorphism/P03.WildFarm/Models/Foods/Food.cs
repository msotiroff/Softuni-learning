namespace P03.WildFarm.Models.Foods
{
    public abstract class Food
    {
        public int Quantity { get; private set; }

        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
