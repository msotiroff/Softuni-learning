public class EnduranceDriver : Driver
{
    private const double InitialFuelConsumption = 1.5;

    public EnduranceDriver(string name, Car car) 
        : base(name, car)
    {
        base.FuelConsumptionPerKm = InitialFuelConsumption;
    }
}
