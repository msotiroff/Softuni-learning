namespace ByTheCake.App.ViewModels
{
    using System.Collections.Generic;

    public class ShoppingCartSessionModel
    {
        public ICollection<int> ProductsIds { get; set; } = new HashSet<int>();
    }
}
