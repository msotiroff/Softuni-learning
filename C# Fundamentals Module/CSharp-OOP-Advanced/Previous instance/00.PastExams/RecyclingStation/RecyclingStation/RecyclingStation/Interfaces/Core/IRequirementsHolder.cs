using System;

namespace RecyclingStation.Interfaces
{
    public interface IRequirementsHolder
    {
        void ChangeRequirements(Type restrictedWasteType, double energyRequirement, double capitalRequirement);
    }
}
