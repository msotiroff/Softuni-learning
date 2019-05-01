namespace WildFarm.Models.Foods
{
    public class Vegetable : Food
    {
        public Vegetable(int foodQuantity)
        {
            base.Quantity = foodQuantity;
        }
    }
}