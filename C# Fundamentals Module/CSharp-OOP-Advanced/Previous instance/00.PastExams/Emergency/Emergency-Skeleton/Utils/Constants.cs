namespace Emergency_Skeleton.Utils
{
    public class Constants
    {
        public const string EndCommand = "EmergencyBreak";
        public const string CommandSuffix = "Command";
        public const string EmergencySuffix = "Emergency";

        public const string FireServiceCenterRegistration = "Registered Fire Service Emergency Center - {0}.";
        public const string MedicalServiceCenterRegistration = "Registered Medical Service Emergency Center - {0}.";
        public const string PoliceServiceCenterRegistration = "Registered Police Service Emergency Center - {0}.";

        public const string OrderEmergencyRegistration = "Registered Public Order Emergency of level {0} at {1}.";
        public const string HealthEmergencyRegistration = "Registered Public Health Emergency of level {0} at {1}.";
        public const string PropertyEmergencyRegistration = "Registered Public Property Emergency of level {0} at {1}.";

        public const string EmergenciesProcessedSuccessfully = "Successfully responded to all {0} emergencies.";
        public const string EmergenciesNotProcessedSuccessfully = "{0} Emergencies left to process: {1}.";
    }
}
