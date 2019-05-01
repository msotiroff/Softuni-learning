using StorageMaster.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Vehicles
{
    public abstract class Vehicle
    {
        private const string VehicleFullErrorMsg = "Vehicle is full!";
        private const string VehicleEmptyErrorMsg = "No products left in vehicle!";

        private List<Product> products;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.products = new List<Product>();
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Product> Trunk => this.products.AsReadOnly();

        public bool IsFull => this.Trunk.Sum(p => p.Weight) >= this.Capacity;

        public bool IsEmpty => this.products.Count == 0;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(VehicleFullErrorMsg);
            }

            this.products.Add(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException(VehicleEmptyErrorMsg);
            }

            var productToUnload = this.products.Last();

            this.products.Remove(productToUnload);

            return productToUnload;
        }
    }
}
