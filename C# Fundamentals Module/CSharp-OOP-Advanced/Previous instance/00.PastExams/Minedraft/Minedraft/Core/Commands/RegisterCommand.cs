using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : BaseCommand
{
    [Inject]
    private IHarvesterController harvesterController;

    [Inject]
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments) 
        : base(arguments)
    {
    }

    public override string Execute()
    {
        var baseType = this.Arguments[0];

        var commandArgs = this.Arguments.Skip(1).ToList();

        var result = string.Empty;

        switch (baseType)
        {
            case nameof(Harvester):
                result = this.harvesterController.Register(commandArgs);
                break;
            case nameof(Provider):
                result = this.providerController.Register(commandArgs);
                break;
            default:
                break;
        }

        return result;
    }
}
