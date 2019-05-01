using System;

public class InfinityHarvester : Harvester
{
    private const double OreOutputDivider = 10.0;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput / OreOutputDivider, energyRequirement)
    {
    }

    public override void Broke()
    {
        // Infinity Harvester cannot be broken!
        var newDurability = this.Durability - 100;
        this.Durability = Math.Max(0, newDurability);
    }
}
