using System.Text;

public abstract class Car
{
    public Car(string brand, string model, int year, int horsePower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = year;
        this.HorsePower = horsePower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public string Brand { get; private set; }

    public string Model { get; private set; }

    public int YearOfProduction { get; private set; }

    public int HorsePower { get; protected set; }

    public int Acceleration { get; private set; }

    public int Suspension { get; protected set; }

    public int Durability { get; set; }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += tuneIndex / 2;
    }

    public int GetTimePerformance()
    {
        var result = ((this.HorsePower / 100) * this.Acceleration);

        return result;
    }

    public int GetSuspensionPerformance()
    {
        var result = this.Suspension + this.Durability;

        return result;
    }

    public int GetEnginePerformance()
    {
        var result = this.HorsePower / this.Acceleration;

        return result;
    }

    public int GetOverallPerformance()
    {
        var result = (this.HorsePower / this.Acceleration) + (this.Suspension + this.Durability);

        return result;
    }

    public override string ToString()
    {
        var result = new StringBuilder()
            .AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}")
            .AppendLine($"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s")
            .AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return result.ToString();
    }
}