namespace P02.VehiclesExtension.Models
{
    using System;

    public class Vehicle
    {
        private double fuelQuantity;
        private double consumption; // liters per km
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double consumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.Consumption = consumption;
            this.TankCapacity = tankCapacity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                this.fuelQuantity = value;
            }
        }

        public double Consumption
        {
            get => this.consumption;

            protected set
            {
                this.consumption = value;
            }
        }

        public double TankCapacity
        {
            get => this.tankCapacity;

            private set
            {
                if (this.fuelQuantity > value)
                {
                    this.fuelQuantity = 0;
                }

                this.tankCapacity = value;
            }
        }

        public virtual void Refuel(double quantity)
        {
            if (quantity <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            if (this.fuelQuantity + quantity > this.tankCapacity)
            {
                throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
            }

            this.fuelQuantity += quantity;
        }

        public virtual void Drive(double destination)
        {
            var neededFuel = destination * this.consumption;

            if (neededFuel > this.fuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.fuelQuantity -= neededFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.fuelQuantity:f2}";
        }
    }
}
