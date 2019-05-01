using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.Waste.Factory
{
    public interface IWasteFactory
    {
        IWaste CreateWaste(string[] arguments);
    }
}