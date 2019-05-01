using System;

namespace StorageMaster.Models.Products
{
    public abstract class Product
    {
        private const string InvalidPriceErrorMsg = "Price cannot be negative!";

        private double price;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Weight { get; private set; }

        public double Price
        {
            get => this.price;

            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException(InvalidPriceErrorMsg);
                }

                this.price = value;
            }
        }

    }
}
