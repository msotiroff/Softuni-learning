namespace ByTheCake.Services.Models
{
    using ByTheCake.Models.Common;
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateServiceModel
    {
        [Required]
        [MinLength(ModelConstants.ProductNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Range(ModelConstants.ProductPriceMinValue, ModelConstants.ProductPriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
