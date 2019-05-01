using System.Collections.Generic;

public class RepairCommand : BaseCommand
{
    private IProviderController providerController;

    public RepairCommand(IList<string> arguments, IProviderController providerController) 
        : base(arguments)
    {
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var value = double.Parse(this.Arguments[0]);

        var result = this.providerController.Repair(value);

        return result;
    }
}
