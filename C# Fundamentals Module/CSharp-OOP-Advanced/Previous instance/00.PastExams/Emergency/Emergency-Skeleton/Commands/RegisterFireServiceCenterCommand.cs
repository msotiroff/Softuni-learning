using System.Collections.Generic;
using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Factories;
using Emergency_Skeleton.Models.EmergencyCenters;

namespace Emergency_Skeleton.Commands
{
    public class RegisterFireServiceCenterCommand : BaseCommand
    {
        private IServiceCenterFactory factory;
        private IEmergencyManagementSystem managementSystem;

        public RegisterFireServiceCenterCommand(IEnumerable<string> arguments) 
            : base(arguments)
        {
        }

        public override string Execute()
        {
            var serviceCenter = this.factory.CreateServiceCenter(nameof(FiremanServiceCenter), this.Arguments);

            var result = this.managementSystem.RegisterFireServiceCenter(serviceCenter);

            return result;
        }
    }
}
