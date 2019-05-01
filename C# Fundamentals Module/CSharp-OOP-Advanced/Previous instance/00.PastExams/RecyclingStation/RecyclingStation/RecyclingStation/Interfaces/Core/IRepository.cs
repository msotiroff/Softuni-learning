using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Interfaces
{
    public interface IRepository
    {
        double CapitalBalance { get; }
        double EnergyBalance { get; }

        void UpdateData(IProcessingData processingData);

        string GetCurrentStatus();
    }
}