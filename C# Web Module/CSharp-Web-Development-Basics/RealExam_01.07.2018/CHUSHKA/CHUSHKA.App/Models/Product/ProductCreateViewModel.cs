namespace CHUSHKA.App.Models.Product
{
    using CHUSHKA.Models.Common;
    using System.ComponentModel.DataAnnotations;

    public class ProductCreateViewModel
    {
        [Required]
        [MinLength(ModelConstants.ProductNameMinLenght, ErrorMessage = "Product name lenght must be between 3 and 20 symbols")]
        [MaxLength(ModelConstants.ProductNameMaxLenght, ErrorMessage = "Product name lenght must be between 3 and 20 symbols")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ProductTypeId { get; set; }
    }
}
