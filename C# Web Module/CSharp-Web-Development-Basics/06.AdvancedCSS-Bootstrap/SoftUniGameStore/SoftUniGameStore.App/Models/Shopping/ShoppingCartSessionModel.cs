using System.Collections.Generic;

namespace SoftUniGameStore.App.Models.Shopping
{
    public class ShoppingCartSessionModel
    {
        public ICollection<int> ProductsIds { get; set; } = new HashSet<int>();
    }
}
