namespace P01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double consumption) 
            : base(fuelQuantity, consumption + 1.6)
        {
        }

        public sealed override void Refuel(double quantity)
        {
            base.Refuel(quantity * 0.95);
        }
    }
}
