namespace P02.VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double consumption, double tankCapacity)
            : base(fuelQuantity, consumption + 0.9, tankCapacity)
        {
        }
    }
}
