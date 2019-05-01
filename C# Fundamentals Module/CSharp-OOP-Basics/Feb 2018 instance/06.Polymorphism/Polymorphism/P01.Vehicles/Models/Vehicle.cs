namespace P01.Vehicles.Models
{
    using System;

    public class Vehicle
    {
        private double fuelQuantity;
        private double consumption; // liters per km

        public Vehicle(double fuelQuantity, double consumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.Consumption = consumption;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;

            protected set
            {
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

        public virtual void Refuel(double quantity)
        {
            this.fuelQuantity += quantity;
        }

        public void Drive(double destination)
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
