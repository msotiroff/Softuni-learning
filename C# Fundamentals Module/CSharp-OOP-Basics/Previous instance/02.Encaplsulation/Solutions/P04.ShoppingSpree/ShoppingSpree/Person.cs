namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
        }

        private string name;

        private decimal money;

        private ICollection<Product> bagOfProducts;
        
        public decimal Money
        {
            get =>  this.money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"{nameof(Money)} cannot be negative");
                }
                this.money = value;
            }
        }


        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Name)} cannot be empty");
                }
                this.name = value;
            }
        }

        internal void AffordProduct(Product product)
        {
            if (product.Cost <= this.Money)
            {
                this.Money -= product.Cost;
                this.bagOfProducts.Add(product);
            }
            else
            {
                throw new ArgumentException($"{this.Name} can't afford {product.Name}");
            }
        }

        internal string PrintBagOfProducts()
        {
            if (!this.bagOfProducts.Any())
            {
                return $"{this.name} - Nothing bought";
            }

            return $"{this.name} - {string.Join(", ", this.bagOfProducts.Select(pr => pr.Name))}";
        }
    }
}
