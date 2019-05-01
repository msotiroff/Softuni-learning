namespace ByTheCake.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<OrderProduct>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal TotalSum { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<OrderProduct> Products { get; set; }
    }
}