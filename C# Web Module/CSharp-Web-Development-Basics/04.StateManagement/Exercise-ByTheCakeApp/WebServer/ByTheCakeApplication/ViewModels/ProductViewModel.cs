using System.ComponentModel.DataAnnotations;

namespace HTTPServer.ByTheCakeApplication.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        [Required]
        [MinLength(3)]
        public string Name { get; private set; }

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; private set; }
    }
}
