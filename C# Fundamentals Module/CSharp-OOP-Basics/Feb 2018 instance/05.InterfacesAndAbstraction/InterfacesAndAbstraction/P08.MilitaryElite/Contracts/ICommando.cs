using System.Collections.Generic;

namespace P08.MilitaryElite.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        List<IMission> Missions { get; }
    }
}
