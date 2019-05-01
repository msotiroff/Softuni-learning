using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Enums;
using Emergency_Skeleton.Models.Emergencies;
using Emergency_Skeleton.Utils;
using System;
using System.Collections.Generic;

namespace Emergency_Skeleton.Commands
{
    public class RegisterPropertyEmergencyCommand : BaseCommand
    {
        private IEmergencyManagementSystem managementSystem;
        private IEmergencyFactory emergencyFactory;

        public RegisterPropertyEmergencyCommand(IEnumerable<string> arguments) 
            : base(arguments)
        {
        }

        public override string Execute()
        {
            var emergency = this.emergencyFactory.CreateEmergency(nameof(PropertyEmergency), this.Arguments);

            var result = this.managementSystem.RegisterPropertyEmergency(emergency);

            return result;
        }
    }
}
