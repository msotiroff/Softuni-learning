using System;

public class Car
{
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get; private set; }

    public double FuelAmount
    {
        get => this.fuelAmount;

        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ErrorMessages.OutOfFuel);
            }

            this.fuelAmount = Math.Min(value, DataConstants.FuelTankMaxCapacity);
        }
    }

    public void ReduceFuel(double fuelAmount)
    {
        this.FuelAmount -= fuelAmount;
    }

    public Tyre Tyre { get; private set; }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }

    public void Refuel(double fuelAmount)
    {
        this.FuelAmount += fuelAmount;
    }
}