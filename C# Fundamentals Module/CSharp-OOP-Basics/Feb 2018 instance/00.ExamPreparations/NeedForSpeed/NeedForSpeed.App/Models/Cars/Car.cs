using System;

public abstract class Car
{
    protected Car(string brand, string model, int year, int horsepower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = year;
        this.Horsepower = horsepower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public int Durability { get; private set; }

    public void DecreaseDurabilityOnEachLap(int value)
    {
        this.Durability -= value;
    }

    public int Suspension { get; protected set; }
    
    public int Acceleration { get; private set; }
    
    public int Horsepower { get; protected set; }
    
    public int YearOfProduction { get; private set; }
    
    public string Model { get; private set; }
    
    public string Brand { get; private set; }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.Horsepower += tuneIndex;
        this.Suspension += tuneIndex / 2;
    }

    public int GetOverallPerformance()
    {
        return (this.Horsepower / this.Acceleration) + (this.Suspension + this.Durability);
    }

    public int GetEnginePerformance()
    {
        return this.Horsepower / this.Acceleration;
    }

    public int GetSuspensionPerformance()
    {
        return this.Suspension + this.Durability;
    }

    public int GetTimePerformance(int raceLength)
    {
        return raceLength * ((this.Horsepower / 100) * this.Acceleration);
    }

    public override string ToString()
    {
        var result = $"{this.Brand} {this.Model} {this.YearOfProduction}{Environment.NewLine}";
        result += $"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s{Environment.NewLine}";
        result += $"{this.Suspension} Suspension force, {this.Durability} Durability";

        return result;
    }
}
