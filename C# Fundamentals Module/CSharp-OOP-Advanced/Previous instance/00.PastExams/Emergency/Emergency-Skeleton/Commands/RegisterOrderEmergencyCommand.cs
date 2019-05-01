using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Models.Emergencies;
using System.Collections.Generic;

namespace Emergency_Skeleton.Commands
{
    public class RegisterOrderEmergencyCommand : BaseCommand
    {
        private IEmergencyManagementSystem managementSystem;
        private IEmergencyFactory emergencyFactory;

        public RegisterOrderEmergencyCommand(IEnumerable<string> arguments) 
            : base(arguments)
        {
        }

        public override string Execute()
        {
            var emergency = this.emergencyFactory.CreateEmergency(nameof(OrderEmergency), this.Arguments);

            var result = this.managementSystem.RegisterOrderEmergency(emergency);

            return result;
        }
    }
}
