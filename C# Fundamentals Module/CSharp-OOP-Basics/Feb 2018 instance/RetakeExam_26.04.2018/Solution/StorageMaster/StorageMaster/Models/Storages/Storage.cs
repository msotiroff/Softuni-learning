using StorageMaster.Models.Products;
using StorageMaster.Models.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Models.Storages
{
    public abstract class Storage
    {
        private const string InvalidSlotErrorMsg = "Invalid garage slot!";
        private const string EmptySlotErrorMsg = "No vehicle in this garage slot!";
        private const string NoFreeCellInGarage = "No room in garage!";
        private const string StorageFullErrorMsg = "Storage is full!";

        private List<Product> products;
        private Vehicle[] garage;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;
            this.garage = new Vehicle[this.GarageSlots];
            this.SeedVehicles(vehicles);
            this.products = new List<Product>();
        }
        
        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public IReadOnlyCollection<Vehicle> Garage => this.garage.ToList().AsReadOnly();

        public bool IsFull => this.Products.Sum(p => p.Weight) >= this.Capacity;
        
        public int UnloadVehicle(int garageSlot)
        {
            var unloadedProducts = 0;

            if (this.IsFull)
            {
                throw new InvalidOperationException(StorageFullErrorMsg);
            }

            var vehicle = this.GetVehicle(garageSlot);

            while (!vehicle.IsEmpty && !this.IsFull)
            {
                var product = vehicle.Unload();

                unloadedProducts++;

                this.products.Add(product);
            }

            return unloadedProducts;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var vehicle = this.GetVehicle(garageSlot);

            var firstFreeSlotDeliveryStorageIndex = Array.IndexOf(deliveryLocation.Garage.ToArray(), null);

            if (firstFreeSlotDeliveryStorageIndex == -1)
            {
                throw new InvalidOperationException(NoFreeCellInGarage);
            }

            this.garage[garageSlot] = null;
            deliveryLocation.garage[firstFreeSlotDeliveryStorageIndex] = vehicle;

            return firstFreeSlotDeliveryStorageIndex;
        }

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.Garage.Count)
            {
                throw new InvalidOperationException(InvalidSlotErrorMsg);
            }

            Vehicle vehicleToReturn = this.garage[garageSlot];

            if (vehicleToReturn == null)
            {
                throw new InvalidOperationException(EmptySlotErrorMsg);
            }

            return vehicleToReturn;
        }

        private void SeedVehicles(IEnumerable<Vehicle> vehicles)
        {
            var inputVehicles = vehicles.ToArray();

            for (int slot = 0; slot < this.garage.Length; slot++)
            {
                Vehicle currentVehicle = null;

                if (slot < inputVehicles.Length)
                {
                    currentVehicle = inputVehicles[slot];
                }

                this.garage[slot] = currentVehicle;
            }
        }

        public override string ToString()
        {
            var totalMoney = this.Products.Sum(p => p.Price);

            return $"{this.Name}:"
                + Environment.NewLine
                + $"Storage worth: ${totalMoney:F2}";

        }
    }
}
