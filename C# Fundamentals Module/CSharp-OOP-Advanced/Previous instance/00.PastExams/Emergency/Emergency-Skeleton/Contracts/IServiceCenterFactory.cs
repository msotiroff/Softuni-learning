using System.Collections.Generic;
using Emergency_Skeleton.Contracts;

namespace Emergency_Skeleton.Contracts
{
    public interface IServiceCenterFactory
    {
        IServiceCenter CreateServiceCenter(string centerType, IEnumerable<string> parameters);
    }
}