using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models
{
    public class ProcessingData : IProcessingData
    {
        public ProcessingData(double energy, double capital)
        {
            this.EnergyBalance = energy;
            this.CapitalBalance = capital;
        }

        public double EnergyBalance { get; }

        public double CapitalBalance { get; }
    }
}
