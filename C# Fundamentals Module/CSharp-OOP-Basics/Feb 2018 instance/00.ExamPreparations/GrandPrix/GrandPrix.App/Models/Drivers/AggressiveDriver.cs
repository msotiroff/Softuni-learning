public class AggressiveDriver : Driver
{
    public AggressiveDriver(string name, Car car) 
        : base(name, car)
    {
        base.FuelConsumptionPerKm = DataConstants.AggressiveDriverDefaultFuelConsumption;
    }

    public override double Speed => base.Speed * DataConstants.AggressiveDriverSpeedMultiplier;
}
