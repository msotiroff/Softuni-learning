using StorageMaster.Factories;
using StorageMaster.Models.Products;
using StorageMaster.Models.Storages;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private List<Product> allProducts;
        private List<Storage> allStorages;
        private Vehicle currentVehicle;

        private StorageFactory storageFactory;
        private VehicleFactory vehicleFactory;
        private ProductFactory productFactory;

        public StorageMaster()
        {
            this.allStorages = new List<Storage>();
            this.allProducts = new List<Product>();

            this.storageFactory = new StorageFactory();
            this.vehicleFactory = new VehicleFactory();
            this.productFactory = new ProductFactory();
        }

        public string AddProduct(string type, double price)
        {
            var product = this.productFactory.CreateProduct(type, price);

            this.allProducts.Add(product);

            var result = $"Added {type} to pool";

            return result;
        }

        public string RegisterStorage(string type, string name)
        {
            var storage = this.storageFactory.CreateStorage(type, name);

            this.allStorages.Add(storage);

            var result = $"Registered {name}";

            return result;
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var storage = this.allStorages.FirstOrDefault(s => s.Name == storageName);

            var vehicle = storage.GetVehicle(garageSlot);

            this.currentVehicle = vehicle;

            var result = $"Selected {this.currentVehicle.GetType().Name}";

            return result;
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var loadedProductsCount = 0;

            foreach (var productName in productNames)
            {
                var productToLoad = this.allProducts.LastOrDefault(p => p.GetType().Name == productName);

                if (productToLoad == null)
                {
                    throw new InvalidOperationException($"{productName} is out of stock!");
                }

                this.allProducts.Remove(productToLoad);

                if (!this.currentVehicle.IsFull)
                {
                    this.currentVehicle.LoadProduct(productToLoad);
                    loadedProductsCount++;
                }
            }

            var result = $"Loaded {loadedProductsCount}/{productNames.Count()} products into {this.currentVehicle.GetType().Name}";

            return result;
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = this.allStorages
                .FirstOrDefault(s => s.Name == sourceName)
                ?? throw new InvalidOperationException("Invalid source storage!");

            var destinationStorage = this.allStorages
                .FirstOrDefault(s => s.Name == destinationName)
                ?? throw new InvalidOperationException("Invalid destination storage!");

            var vehicleType = sourceStorage.GetVehicle(sourceGarageSlot).GetType().Name;

            var destinationGarageSlot = sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            var result = $"Sent {vehicleType} to {destinationName} (slot {destinationGarageSlot})";

            return result;
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.allStorages.FirstOrDefault(s => s.Name == storageName);

            var productsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count;

            var unloadedProducts = storage.UnloadVehicle(garageSlot);

            var result = $"Unloaded {unloadedProducts}/{productsInVehicle} products at {storageName}";

            return result;
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.allStorages.FirstOrDefault(s => s.Name == storageName);
            var productsCount = storage.Products.Count;
            var productsWeight = storage.Products.Sum(p => p.Weight);
            
            var products = storage
                .Products
                .GroupBy(p => p.GetType().Name)
                .ToDictionary(x => x.Key, x => x.Count())
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            var stockInfo = string.Join(" ,", products.Select(p => $"{p.Key} ({p.Value})"));

            var result = $"Stock ({productsWeight}/{storage.Capacity}): [{stockInfo}]";

            var garageInfo = string.Join("|", storage.Garage.Select(v => v?.GetType().Name ?? "empty"));

            result += Environment.NewLine;
            result += $"Garage: [{garageInfo}]";

            return result;
        }

        public string GetSummary()
        {
            var builder = new StringBuilder();
            var orderedStorages = this.allStorages.OrderByDescending(s => s.Products.Sum(p => p.Price)).ToList();

            orderedStorages
                .ForEach(os => builder.AppendLine(os.ToString()));

            var result = builder.ToString().TrimEnd();

            return result;
        }

    }
}
