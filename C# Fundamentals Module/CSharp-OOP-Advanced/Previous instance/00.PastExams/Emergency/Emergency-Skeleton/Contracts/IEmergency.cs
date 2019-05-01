using Emergency_Skeleton.Enums;
using Emergency_Skeleton.Utils;

namespace Emergency_Skeleton.Contracts
{
    public interface IEmergency
    {
        string Description { get;  }
        EmergencyLevel Level { get;  }
        RegistrationTime Time { get;  }
    }
}