using System.Collections.Generic;

public class RepairCommand : BaseCommand
{
    [Inject]
    private IProviderController providerController;

    public RepairCommand(IList<string> arguments) 
        : base(arguments)
    {
    }

    public override string Execute()
    {
        var repairValue = double.Parse(this.Arguments[0]);

        var result = this.providerController.Repair(repairValue);

        return result;
    }
}
