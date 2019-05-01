using Emergency_Skeleton.Attributes;
using Emergency_Skeleton.Contracts;

namespace Emergency_Skeleton.Models.EmergencyCenters
{
    [PropertyDepartment]
    public class FiremanServiceCenter : BaseEmergencyCenter
    {
        public FiremanServiceCenter(string name, int amountOfMaximumEmergencies) 
            : base(name, amountOfMaximumEmergencies)
        {
        }
    }
}
