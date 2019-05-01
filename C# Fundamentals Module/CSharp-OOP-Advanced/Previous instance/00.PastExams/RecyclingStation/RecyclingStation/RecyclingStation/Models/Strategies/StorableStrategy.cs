using RecyclingStation.Extensions.CustomAttributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.Strategies
{
    [Storable]
    public class StorableStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energyProduced = 0;
            var energyUsed = garbage.Weight * garbage.VolumePerKg * 0.13;
            var energy = energyProduced - energyUsed;

            var capitalEarned = 0;
            var capitalUsed = garbage.Weight * garbage.VolumePerKg * 0.65;
            var capital = capitalEarned - capitalUsed;

            var processingData = new ProcessingData(energy, capital);

            return processingData;
        }
    }
}
