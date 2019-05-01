namespace KittenShop.App.Models.Shopping
{
	using System.Collections.Generic;
	
    public class ShoppingCart
    {
        public HashSet<int> Ids { get; set; } = new HashSet<int>();
    }
}
