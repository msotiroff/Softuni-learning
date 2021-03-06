﻿namespace CHUSHKA.Models
{
    using System.ComponentModel.DataAnnotations;
    using CHUSHKA.Models.Common;

    public class Product
    {
        [Key]
        public int Id { get; set; }

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
        
        public ProductType ProductType { get; set; }
    }
}
