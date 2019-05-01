using System;

class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumptionFor1km;
    private double distanceTraveled;

    public Car(string model, double fuelAmount, double consumptionPerKm)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumptionFor1km = consumptionPerKm;
        this.distanceTraveled = 0;
    }

    public double DistanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }


    public double FuelConsumptionFor1km
    {
        get { return fuelConsumptionFor1km; }
        set { fuelConsumptionFor1km = value; }
    }


    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }


    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public void Drive (double distance)
    {
        var neededFuel = distance * this.fuelConsumptionFor1km;

        if (neededFuel > this.fuelAmount)
        {
            throw new InvalidOperationException("Insufficient fuel for the drive");
        }

        this.fuelAmount -= neededFuel;
        this.distanceTraveled += distance;
    }

    public override string ToString()
    {
        return $"{this.model} {this.fuelAmount:f2} {this.distanceTraveled}";
    }
}