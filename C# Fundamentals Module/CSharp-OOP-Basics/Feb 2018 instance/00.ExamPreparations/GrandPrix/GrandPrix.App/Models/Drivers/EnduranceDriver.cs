public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, Car car) 
        : base(name, car)
    {
        base.FuelConsumptionPerKm = DataConstants.EnduranceDriverDefaultFuelConsumption;
    }
}
