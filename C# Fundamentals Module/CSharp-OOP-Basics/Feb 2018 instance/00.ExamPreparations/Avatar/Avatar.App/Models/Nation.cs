using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    public IList<Bender> Benders { get; set; } = new List<Bender>();

    public IList<Monument> Monuments { get; set; } = new List<Monument>();

    public double GetTotalPower()
    {
        double bendersPower = this.Benders
            .Sum(b => b.Power * b.GetSpecialCharacteristic());

        double affinityPercentage = this.Monuments.Any()
            ? this.Monuments.Sum(m => m.GetAffinity())
            : 100.0;

        double result = bendersPower * affinityPercentage / 100;

        return result;
    }

    public void KillThemAll()
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
    }

    public override string ToString()
    {
        var benders = this
            .Benders
            .Select(b => $"###{b.ToString()}");

        var monuments = this
            .Monuments
            .Select(m => $"###{m.ToString()}");

        var bendersToBePrinted = benders.Any()
            ? $"Benders:{Environment.NewLine}{string.Join(Environment.NewLine, benders)}"
            : "Benders: None";

        var monumentsToBePrinted = monuments.Any()
            ? $"Monuments:{Environment.NewLine}{string.Join(Environment.NewLine, monuments)}"
            : "Monuments: None";

        var builder = new StringBuilder()
            .AppendLine(bendersToBePrinted)
            .AppendLine(monumentsToBePrinted);

        var result = builder.ToString().TrimEnd();

        return result;
    }
}
