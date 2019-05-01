using Emergency_Skeleton.Attributes;

namespace Emergency_Skeleton.Models.EmergencyCenters
{
    [OrderDepartment]
    public class PoliceServiceCenter : BaseEmergencyCenter
    {
        public PoliceServiceCenter(string name, int amountOfMaximumEmergencies) 
            : base(name, amountOfMaximumEmergencies)
        {
        }
    }
}
