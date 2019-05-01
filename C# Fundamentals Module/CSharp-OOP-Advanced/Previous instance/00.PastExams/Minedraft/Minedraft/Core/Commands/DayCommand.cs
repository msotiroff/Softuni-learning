using System.Collections.Generic;
using System.Text;

public class DayCommand : BaseCommand
{
    [Inject]
    private IHarvesterController harvesterController;

    [Inject]
    private IProviderController providerController;

    public DayCommand(IList<string> arguments) 
        : base(arguments)
    {
    }

    public override string Execute()
    {
        var builder = new StringBuilder();

        builder.AppendLine(this.providerController.Produce());
        builder.AppendLine(this.harvesterController.Produce());

        var result = builder.ToString().TrimEnd();

        return result;
    }
}
