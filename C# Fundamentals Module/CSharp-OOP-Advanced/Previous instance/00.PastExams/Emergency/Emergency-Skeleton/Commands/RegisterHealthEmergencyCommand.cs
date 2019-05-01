using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Models.Emergencies;
using System.Collections.Generic;

namespace Emergency_Skeleton.Commands
{
    public class RegisterHealthEmergencyCommand : BaseCommand
    {
        private IEmergencyManagementSystem managementSystem;
        private IEmergencyFactory emergencyFactory;

        public RegisterHealthEmergencyCommand(IEnumerable<string> arguments) 
            : base(arguments)
        {
        }

        public override string Execute()
        {
            var emergency = this.emergencyFactory.CreateEmergency(nameof(HealthEmergency), this.Arguments);

            var result = this.managementSystem.RegisterHealthEmergency(emergency);

            return result;
        }
    }
}
