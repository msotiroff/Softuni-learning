using System.Collections.Generic;
using System.Linq;
using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Utils;

namespace Emergency_Skeleton.Commands
{
    public class ProcessEmergenciesCommand : BaseCommand
    {
        private IEmergencyManagementSystem managementSystem;

        public ProcessEmergenciesCommand(IEnumerable<string> arguments) 
            : base(arguments)
        {
        }

        public override string Execute()
        {
            var emergencyType = this.Arguments.ToArray()[0] + Constants.EmergencySuffix;

            var result = this.managementSystem.ProcessEmergencies(emergencyType);

            return result;
        }
    }
}
