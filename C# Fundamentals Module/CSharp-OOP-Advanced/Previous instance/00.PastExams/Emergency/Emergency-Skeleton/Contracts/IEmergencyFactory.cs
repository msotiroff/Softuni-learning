using System.Collections.Generic;
using Emergency_Skeleton.Contracts;

namespace Emergency_Skeleton.Contracts
{
    public interface IEmergencyFactory
    {
        IEmergency CreateEmergency(string typeName, IEnumerable<string> parameters);
    }
}