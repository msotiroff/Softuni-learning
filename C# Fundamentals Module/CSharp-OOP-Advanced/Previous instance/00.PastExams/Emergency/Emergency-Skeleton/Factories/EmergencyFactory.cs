using Emergency_Skeleton.Contracts;
using Emergency_Skeleton.Enums;
using Emergency_Skeleton.Models.Emergencies;
using Emergency_Skeleton.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emergency_Skeleton.Factories
{
    public class EmergencyFactory : IEmergencyFactory
    {
        public IEmergency CreateEmergency(string typeName, IEnumerable<string> parameters)
        {
            var args = parameters.ToArray();
            IEmergency emergency = null;

            // {description}|{level}|{registrationTime}|{specificParameter}
            var description = args[0];
            var level = (EmergencyLevel)Enum.Parse(typeof(EmergencyLevel), args[1]);
            var registrationTime = new RegistrationTime(args[2]);

            switch (typeName)
            {
                case nameof(PropertyEmergency):
                    var damage = int.Parse(args[3]);
                    emergency = new PropertyEmergency(description, level, registrationTime, damage);
                    break;

                case nameof(HealthEmergency):
                    var numberOfCasualities = int.Parse(args[3]);
                    emergency = new HealthEmergency(description, level, registrationTime, numberOfCasualities);
                    break;

                case nameof(OrderEmergency):
                    var status = args[3] == "Special" ? Status.Special : Status.NonSpecial;
                    emergency = new OrderEmergency(description, level, registrationTime, status);
                    break;
                default:
                    break;
            }
            
            return emergency;
        }
    }
}
