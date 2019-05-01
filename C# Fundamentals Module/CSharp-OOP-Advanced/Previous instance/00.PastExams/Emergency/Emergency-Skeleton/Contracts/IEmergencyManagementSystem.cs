using System.Collections.Generic;

namespace Emergency_Skeleton.Contracts
{
    public interface IEmergencyManagementSystem
    {
        string EmergencyReport();
        string ProcessEmergencies(string emergencyType);
        string RegisterFireServiceCenter(IServiceCenter serviceCenter);
        string RegisterHealthEmergency(IEmergency emergency);
        string RegisterMedicalServiceCenter(IServiceCenter serviceCenter);
        string RegisterOrderEmergency(IEmergency emergency);
        string RegisterPoliceServiceCenter(IServiceCenter serviceCenter);
        string RegisterPropertyEmergency(IEmergency emergency);
    }
}