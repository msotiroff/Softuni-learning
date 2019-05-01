using Emergency_Skeleton.Attributes;

namespace Emergency_Skeleton.Models.EmergencyCenters
{
    [HealtDepartment]
    public class MedicalServiceCenter : BaseEmergencyCenter
    {
        public MedicalServiceCenter(string name, int amountOfMaximumEmergencies) 
            : base(name, amountOfMaximumEmergencies)
        {
        }
    }
}
