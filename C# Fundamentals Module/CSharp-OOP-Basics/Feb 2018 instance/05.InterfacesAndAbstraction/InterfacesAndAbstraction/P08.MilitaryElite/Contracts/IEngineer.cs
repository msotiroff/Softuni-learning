using System.Collections.Generic;

namespace P08.MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        List<IRepair> Repairs { get; }
    }
}
