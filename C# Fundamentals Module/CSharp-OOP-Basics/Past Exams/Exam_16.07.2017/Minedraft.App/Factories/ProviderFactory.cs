using System.Collections.Generic;

public class ProviderFactory
{
    public static Provider CreateInstance(List<string> arguments)
    {
        var providerType = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        Provider provider = null;

        if (providerType == "Solar")
        {
            provider = new SolarProvider(id, energyOutput);
        }
        else if (providerType == "Pressure")
        {
            provider = new PressureProvider(id, energyOutput);
        }

        return provider;
    }
}