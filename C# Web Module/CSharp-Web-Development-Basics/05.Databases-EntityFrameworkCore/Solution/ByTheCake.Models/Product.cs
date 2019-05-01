namespace ByTheCake.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.Orders = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelConstants.ProductNameMinLength)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(ModelConstants.ProductPriceMinValue, ModelConstants.ProductPriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<OrderProduct> Orders { get; set; }
    }
}