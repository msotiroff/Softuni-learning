using System.Data.Entity;

namespace ShoppingList.Models
{
    public class ShoppingListDbContext : DbContext
    {
        public ShoppingListDbContext() : base("ShoppingList")
        {
        }

        public virtual IDbSet<Product> Products { get; set; }
    }
}