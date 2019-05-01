using Emergency_Skeleton.Attributes;
using Emergency_Skeleton.Enums;
using Emergency_Skeleton.Utils;

namespace Emergency_Skeleton.Models.Emergencies
{
    [HealtDepartment]
    public class HealthEmergency : BaseEmergency
    {
        public HealthEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, int numberOfCasualities) 
            : base(description, emergencyLevel, registrationTime)
        {
            this.NumberOfCasualties = numberOfCasualities;
        }

        public int NumberOfCasualties { get; private set; }
    }
}
