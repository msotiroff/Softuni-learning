using System;
using System.Collections.Generic;
using System.Linq;

public class InspectCommand : BaseCommand
{
    [Inject]
    HarvesterController harvesterController;

    [Inject]
    ProviderController providerController;

    public InspectCommand(IList<string> arguments)
        : base(arguments)
    {
    }

    public override string Execute()
    {
        var id = int.Parse(this.Arguments[0]);

        var allEntities = this.harvesterController
            .Entities
            .Concat(this.providerController
                .Entities)
            .ToArray();

        var neededEntity = allEntities.FirstOrDefault(e => e.ID == id);

        if (neededEntity == null)
        {
            return string.Format(Constants.EntityNotFound, id);
        }

        var entityToString = $"{neededEntity.GetType().Name}"
            + Environment.NewLine
            + $"Durability: {neededEntity.Durability}";

        return entityToString;
    }
}
