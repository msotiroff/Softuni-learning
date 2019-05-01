namespace HTTPServer.ByTheCakeApplication.ViewModels
{
    using System.Collections.Generic;

    public class ShoppingCartViewModel
    {
        public ICollection<ProductViewModel> Products { get; set; } = new HashSet<ProductViewModel>();
    }
}
