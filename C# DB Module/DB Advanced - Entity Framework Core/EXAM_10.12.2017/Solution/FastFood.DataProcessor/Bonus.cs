namespace FastFood.DataProcessor
{
    using FastFood.Data;
    using System.Linq;

    public static class Bonus
    {
	    public static string UpdatePrice(FastFoodDbContext context, string itemName, decimal newPrice)
	    {
            var itemToUpdatePrice = context.Items
                .FirstOrDefault(i => i.Name == itemName);

            var result = string.Empty;

            if (itemToUpdatePrice == null)
            {
                result = $"Item {itemName} not found!";
            }
            else
            {
                var oldPrice = itemToUpdatePrice.Price;

                itemToUpdatePrice.Price = newPrice;
                context.SaveChanges();

                result = $"{itemName} Price updated from ${oldPrice:F2} to ${newPrice:F2}";
            }

            return result;
	    }
    }
}
