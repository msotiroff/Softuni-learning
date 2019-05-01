namespace ByTheCake.Services.Models
{
    using System;
    using System.Collections.Generic;

    public class OrderListServiceModel
    {
        public int Id { get; set; }
        
        public DateTime CreationDate { get; set; }

        public decimal TotalSum { get; set; }

        public ICollection<ProductListServiceModel> Products { get; set; }
    }
}
