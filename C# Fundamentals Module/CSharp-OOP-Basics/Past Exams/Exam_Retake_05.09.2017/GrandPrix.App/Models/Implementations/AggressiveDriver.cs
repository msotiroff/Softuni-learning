public class AggressiveDriver : Driver
{
    private const double InitialFuelConsumption = 2.7;
    private const double SpeedMultiplier = 1.3;

    public AggressiveDriver(string name, Car car) 
        : base(name, car)
    {
        base.FuelConsumptionPerKm = InitialFuelConsumption;
    }

    public override double Speed => base.Speed * SpeedMultiplier;
}