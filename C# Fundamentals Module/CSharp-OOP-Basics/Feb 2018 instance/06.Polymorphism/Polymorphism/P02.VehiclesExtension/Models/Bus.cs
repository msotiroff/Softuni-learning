namespace P02.VehiclesExtension.Models
{
    using System;

    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double consumption, double tankCapacity) 
            : base(fuelQuantity, consumption, tankCapacity)
        {
        }

        public override void Drive(double destination)
        {
            var neededFuel = destination * (base.Consumption + 1.4);

            if (neededFuel > base.FuelQuantity)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            base.FuelQuantity -= neededFuel;
        }

        public void DriveEmpty (double destination)
        {
            base.Drive(destination);
        }
    }
}
