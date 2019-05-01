using System;
using System.Collections.Generic;

public class DayCommand : BaseCommand
{
    private IProviderController providerController;
    IHarvesterController harvesterController;

    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var energyProducedToday = this.providerController.Produce();
        var oreOutputToday = this.harvesterController.Produce();

        var result = energyProducedToday
            + Environment.NewLine
            + oreOutputToday;

        return result;
    }
}
