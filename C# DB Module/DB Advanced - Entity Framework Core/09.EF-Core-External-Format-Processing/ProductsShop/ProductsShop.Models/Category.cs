namespace ProductsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Category
    {
        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        public ICollection<CategoryProduct> Products { get; set; } = new HashSet<CategoryProduct>();
    }
}
