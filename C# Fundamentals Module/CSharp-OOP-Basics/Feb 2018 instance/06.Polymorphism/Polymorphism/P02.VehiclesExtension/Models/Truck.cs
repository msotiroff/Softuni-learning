namespace P02.VehiclesExtension.Models
{
    using System;

    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumption, double tankCapacity) 
            : base(fuelQuantity, consumption + 1.6, tankCapacity)
        {
        }

        public sealed override void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (base.FuelQuantity + quantity > base.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
            }

            base.FuelQuantity += quantity * 0.95;
        }
    }
}
