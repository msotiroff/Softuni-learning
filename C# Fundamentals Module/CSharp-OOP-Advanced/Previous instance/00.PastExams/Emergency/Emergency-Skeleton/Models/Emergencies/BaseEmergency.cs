namespace Emergency_Skeleton.Models
{
    using Emergency_Skeleton.Contracts;
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    public abstract class BaseEmergency : IEmergency
    {
        private string description;

        private EmergencyLevel emergencyLevel;

        private RegistrationTime registrationTime;

        protected BaseEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime)
        {
            this.Description = description;
            this.emergencyLevel = emergencyLevel;
            this.registrationTime = registrationTime;
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            private set
            {
                this.description = value;
            }
        }

        public EmergencyLevel Level
        {
            get
            {
                return this.emergencyLevel;
            }
            private set
            {
                this.emergencyLevel = value;
            }
        }

        public RegistrationTime Time
        {
            get
            {
                return this.registrationTime;
            }
            private set
            {
                this.registrationTime = value;
            }
        }
    }
}
