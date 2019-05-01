using System;
class Car
{
    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumptionPerKm { get; set; }
    public double DistanceTraveled { get; set; }

    public Car(string model, double fuelAmount, double consumption)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionPerKm = consumption;
        this.DistanceTraveled = 0;
    }

    public void Drive (double distance)
    {
        if (this.FuelAmount < this.FuelConsumptionPerKm * distance)
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
        else
        {
            this.FuelAmount -= this.FuelConsumptionPerKm * distance;
            this.DistanceTraveled += distance;
        }
    }
}
