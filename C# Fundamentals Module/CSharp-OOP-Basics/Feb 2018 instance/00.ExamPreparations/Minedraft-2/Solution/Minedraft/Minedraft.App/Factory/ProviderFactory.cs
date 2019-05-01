using System.Collections.Generic;

public class ProviderFactory : IProviderFactory
{
    public Provider GenerateProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        Provider provider = null;

        switch (type)
        {
            case "Solar":
                provider = new SolarProvider(id, energyOutput);
                break;
            case "Pressure":
                provider = new PressureProvider(id, energyOutput);
                break;
            default:
                break;
        }

        return provider;
    }
}