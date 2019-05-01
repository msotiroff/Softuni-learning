using System.Collections.Generic;
using System.Linq;

public class InspectCommand : BaseCommand
{
    IHarvesterController harvesterController;
    IProviderController providerController;

    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {

        var allEntities = this.harvesterController.Entities.Concat(this.providerController.Entities).ToList();

        var id = int.Parse(this.Arguments[0]);

        var neededEntity = allEntities.FirstOrDefault(e => e.ID == id);

        if (neededEntity == null)
        {
            return string.Format(Constants.NoEntityFound, id);
        }

        return neededEntity.ToString();
    }
}
