using RecyclingStation.Common;
using RecyclingStation.Interfaces;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Core
{
    public class RecyclingStationRepository : IRepository
    {
        public double EnergyBalance { get; private set; }

        public double CapitalBalance { get; private set; }

        public string GetCurrentStatus()
        {
            return string.Format(Constants.StationCurrentStatusMsg,
                    this.EnergyBalance.ToString(Constants.FloatingPointNumbersFormat),
                    this.CapitalBalance.ToString(Constants.FloatingPointNumbersFormat));
        }

        public void UpdateData(IProcessingData processingData)
        {
            this.EnergyBalance += processingData.EnergyBalance;
            this.CapitalBalance += processingData.CapitalBalance;
        }
    }
}
