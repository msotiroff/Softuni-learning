namespace ProductsShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        private string lastName;

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last Name should be at least 3 symbols");
                }

                this.lastName = value;
            }
        }


        public int? Age { get; set; }

        public ICollection<Product> ProductsSold { get; set; } = new HashSet<Product>();

        public ICollection<Product> ProductsBought { get; set; } = new HashSet<Product>();
    }
}
