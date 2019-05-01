using System;

public class InfinityHarvester : Harvester
{
    private const double OreOutputDivider = 10;

    private double durability;
    
    public InfinityHarvester(int id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= OreOutputDivider;
    }

    public override void Broke()
    {
        // Infinity harvester cannot be broken, so nothing happens here!
    }
}