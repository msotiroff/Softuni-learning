namespace P01.Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double consumption) 
            : base(fuelQuantity, consumption + 0.9)
        {
        }
    }
}
