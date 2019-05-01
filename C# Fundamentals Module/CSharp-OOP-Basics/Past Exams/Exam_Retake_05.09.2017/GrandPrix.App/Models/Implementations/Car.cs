using System;

public class Car : ICar
{
    private const double MaxTankCapacity = 160.0;
    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return this.hp; }
        private set { this.hp = value; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        protected set
        {
            this.fuelAmount = Math.Min(value, MaxTankCapacity);

            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }
        }
    }

    public Tyre Tyre
    {
        get { return this.tyre; }
        private set { this.tyre = value; }
    }

    public void ChangeTyre(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void Refuel(double amountToRefuel)
    {
        this.FuelAmount += amountToRefuel;
    }

    public void SpendFuel(int trackLength, double fuelConsumptionPerKm)
    {
        this.FuelAmount -= trackLength * fuelConsumptionPerKm;
    }
}