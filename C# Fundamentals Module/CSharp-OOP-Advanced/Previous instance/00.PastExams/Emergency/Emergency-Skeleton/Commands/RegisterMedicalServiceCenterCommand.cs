using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Models.EmergencyCenters;
using System.Collections.Generic;

namespace Emergency_Skeleton.Commands
{
    public class RegisterMedicalServiceCenterCommand : BaseCommand
    {
        private IServiceCenterFactory factory;
        private IEmergencyManagementSystem managementSystem;

        public RegisterMedicalServiceCenterCommand(IEnumerable<string> arguments) 
            : base(arguments)
        {
        }

        public override string Execute()
        {
            var serviceCenter = this.factory.CreateServiceCenter(nameof(MedicalServiceCenter), this.Arguments);

            var result = this.managementSystem.RegisterMedicalServiceCenter(serviceCenter);

            return result;
        }
    }
}
