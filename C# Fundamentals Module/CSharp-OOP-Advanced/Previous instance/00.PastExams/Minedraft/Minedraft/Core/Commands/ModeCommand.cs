using System.Collections.Generic;

public class ModeCommand : BaseCommand
{
    [Inject]
    private IHarvesterController harvesterController;

    public ModeCommand(IList<string> arguments) 
        : base(arguments)
    {
    }

    public override string Execute()
    {
        var newMode = this.Arguments[0];

        var result = this.harvesterController.ChangeMode(newMode);

        return result;
    }
}
