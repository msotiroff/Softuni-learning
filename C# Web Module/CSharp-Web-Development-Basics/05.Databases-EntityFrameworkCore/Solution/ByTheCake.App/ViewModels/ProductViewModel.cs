using System.ComponentModel.DataAnnotations;

namespace ByTheCake.App.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel(int id, string name, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; private set; }

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; private set; }
    }
}
