namespace ByTheCake.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class OrderCreateServiceModel
    {
        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public decimal TotalSum { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public ICollection<int> ProductsIds { get; set; }
    }
}
