using System.Collections.Generic;

public class ModeCommand : BaseCommand
{
    private IHarvesterController harvesterController;

    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController) 
        : base(arguments)
    {
        this.harvesterController = harvesterController;
    }

    public override string Execute()
    {
        var result = this.harvesterController.ChangeMode(this.Arguments[0]);

        return result;
    }
}
