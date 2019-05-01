using Emergency_Skeleton.Attributes;
using Emergency_Skeleton.Enums;
using Emergency_Skeleton.Utils;

namespace Emergency_Skeleton.Models.Emergencies
{
    [PropertyDepartment]
    public class PropertyEmergency : BaseEmergency
    {
        public PropertyEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, int damage) 
            : base(description, emergencyLevel, registrationTime)
        {
            this.Damage = damage;
        }

        public int Damage { get; private set; }
    }
}
