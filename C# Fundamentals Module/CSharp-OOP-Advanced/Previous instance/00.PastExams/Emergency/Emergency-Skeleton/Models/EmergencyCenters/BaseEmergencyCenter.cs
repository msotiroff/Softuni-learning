using Emergency_Skeleton.Contracts;
using System;
using System.Collections.Generic;

namespace Emergency_Skeleton.Models
{
    public abstract class BaseEmergencyCenter : IServiceCenter
    {
        private string name;
        private int amountOfMaximumEmergencies;
        private List<IEmergency> processedEmergencies;

        protected BaseEmergencyCenter(string name, int amountOfMaximumEmergencies)
        {
            this.Name = name;
            this.amountOfMaximumEmergencies = amountOfMaximumEmergencies;
            this.processedEmergencies = new List<IEmergency>();
        }

        public IReadOnlyList<IEmergency> ProcessedEmergencies => this.processedEmergencies.AsReadOnly();

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int AmountOfMaximumEmergencies
        {
            get
            {
                return this.amountOfMaximumEmergencies;
            }
            private set
            {
                this.amountOfMaximumEmergencies = value;
            }
        }

        public bool IsForRetirement() => this.AmountOfMaximumEmergencies == this.ProcessedEmergencies.Count;

        public void AddEmergency(IEmergency emergency)
        {
            this.processedEmergencies.Add(emergency);
        }
    }
}
