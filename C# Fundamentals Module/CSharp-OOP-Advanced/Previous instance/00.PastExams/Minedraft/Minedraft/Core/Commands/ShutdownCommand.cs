using System;
using System.Collections.Generic;

public class ShutdownCommand : BaseCommand
{
    [Inject]
    IHarvesterController harvesterController;

    [Inject]
    IProviderController providerController;

    public ShutdownCommand(IList<string> arguments) 
        : base(arguments)
    {
    }

    public override string Execute()
    {
        var totalOreMined = this.harvesterController.OreProduced;
        var totalEnergyProduces = this.providerController.TotalEnergyProduced;

        var result = "System Shutdown"
            + Environment.NewLine
            + $"Total Energy Produced: {totalEnergyProduces}"
            + Environment.NewLine
            + $"Total Mined Plumbus Ore: {totalOreMined}";

        return result;
    }
}
