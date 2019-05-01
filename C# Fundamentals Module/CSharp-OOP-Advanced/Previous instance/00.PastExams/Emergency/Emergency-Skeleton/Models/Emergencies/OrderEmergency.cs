using Emergency_Skeleton.Attributes;
using Emergency_Skeleton.Enums;
using Emergency_Skeleton.Utils;

namespace Emergency_Skeleton.Models.Emergencies
{
    [OrderDepartment]
    public class OrderEmergency : BaseEmergency
    {
        public OrderEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, Status status) 
            : base(description, emergencyLevel, registrationTime)
        {
            this.Status = status;
        }

        public Status Status { get; private set; }
    }
}
