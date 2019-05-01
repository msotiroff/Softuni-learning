using System;
using System.Collections.Generic;

public class ShutdownCommand : BaseCommand
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var result = Constants.SystemShutdown
            + Environment.NewLine
            + string.Format(Constants.TotalEnergyProduced, this.providerController.TotalEnergyProduced)
            + Environment.NewLine
            + string.Format(Constants.TotalOreMined, this.harvesterController.OreProduced);

        return result;
    }
}
