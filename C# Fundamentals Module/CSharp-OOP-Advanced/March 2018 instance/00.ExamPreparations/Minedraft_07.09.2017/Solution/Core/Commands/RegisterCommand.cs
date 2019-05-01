using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : BaseCommand
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var typeOfEntity = this.Arguments[0];

        var result = string.Empty;

        switch (typeOfEntity)
        {
            case nameof(Provider):
                result = this.providerController.Register(this.Arguments.Skip(1).ToList());
                break;

            case nameof(Harvester):
                result = this.harvesterController.Register(this.Arguments.Skip(1).ToList());
                break;

            default:
                break;
        }

        return result;
    }
}
