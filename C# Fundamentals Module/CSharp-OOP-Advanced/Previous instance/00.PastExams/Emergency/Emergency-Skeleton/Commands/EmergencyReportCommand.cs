using System.Collections.Generic;
using Emergency_Skeleton.Contracts;

namespace Emergency_Skeleton.Commands
{
    public class EmergencyReportCommand : BaseCommand
    {
        IEmergencyManagementSystem managementSystem;

        public EmergencyReportCommand(IEnumerable<string> arguments) 
            : base(arguments)
        {
        }

        public override string Execute()
        {
            var result = this.managementSystem.EmergencyReport();

            return result;
        }
    }
}
