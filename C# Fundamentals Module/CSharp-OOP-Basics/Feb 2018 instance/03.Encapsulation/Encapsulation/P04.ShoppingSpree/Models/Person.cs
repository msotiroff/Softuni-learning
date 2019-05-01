using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal mondey;
        private List<Product> bagOfProducts;

        public Person(string name, decimal mondey)
        {
            this.Name = name;
            this.Money = mondey;
            this.bagOfProducts = new List<Product>();
        }

        public IReadOnlyList<Product> BagOfProducts
        {
            get => this.bagOfProducts;
        }

        public decimal Money
        {
            get => this.mondey;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.mondey = value;
            }
        }
        
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public void BuyProduct(Product product)
        {
            if (this.mondey < product.Cost)
            {
                throw new InvalidOperationException($"{this.name} can't afford {product.Name}");
            }

            this.mondey -= product.Cost;
            this.bagOfProducts.Add(product);
        }

        public override string ToString()
        {
            var boughtProducts = this.bagOfProducts.Count > 0
                ? string.Join(", ", this.bagOfProducts.Select(pr => pr.Name))
                : "Nothing bought";

            return $"{this.name} - {boughtProducts}";
        }
    }
}
