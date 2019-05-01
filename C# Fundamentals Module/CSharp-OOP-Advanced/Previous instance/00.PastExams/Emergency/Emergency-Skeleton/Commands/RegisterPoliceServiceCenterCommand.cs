using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Models.EmergencyCenters;
using System.Collections.Generic;

namespace Emergency_Skeleton.Commands
{
    public class RegisterPoliceServiceCenterCommand : BaseCommand
    {
        private IServiceCenterFactory factory;
        private IEmergencyManagementSystem managementSystem;

        public RegisterPoliceServiceCenterCommand(IEnumerable<string> arguments) 
            : base(arguments)
        {
        }

        public override string Execute()
        {
            var serviceCenter = this.factory.CreateServiceCenter(nameof(PoliceServiceCenter), this.Arguments);

            var result = this.managementSystem.RegisterPoliceServiceCenter(serviceCenter);

            return result;
        }
    }
}
