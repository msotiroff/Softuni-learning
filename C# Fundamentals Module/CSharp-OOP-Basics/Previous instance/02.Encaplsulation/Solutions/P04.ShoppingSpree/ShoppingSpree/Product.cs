namespace ShoppingSpree
{
    using System;

    internal class Product
    {
        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        private string name;

        private decimal cost;

        public decimal Cost
        {
            get { return this.cost; }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.cost = value;
            }
        }
        
        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"{nameof(Name)} cannot be empty");
                }
                this.name = value;
            }
        }

    }
}
