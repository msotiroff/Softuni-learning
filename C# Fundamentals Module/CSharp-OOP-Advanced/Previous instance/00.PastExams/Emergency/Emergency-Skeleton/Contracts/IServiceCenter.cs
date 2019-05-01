using System.Collections.Generic;

namespace Emergency_Skeleton.Contracts
{
    public interface IServiceCenter
    {
        int AmountOfMaximumEmergencies { get; }
        string Name { get; }
        IReadOnlyList<IEmergency> ProcessedEmergencies { get; }

        void AddEmergency(IEmergency emergency);
        bool IsForRetirement();
    }
}