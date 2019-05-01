using RecyclingStation.Extensions.CustomAttributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.Strategies
{
    [Burnable]
    public class BurnableStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energyProduced = garbage.Weight * garbage.VolumePerKg;
            var energyUsed = garbage.Weight * garbage.VolumePerKg * 0.2;
            var energy = energyProduced - energyUsed;

            var capitalEarned = 0;
            var capitalUsed = 0;
            var capital = capitalEarned - capitalUsed;

            var processingData = new ProcessingData(energy, capital);

            return processingData;
        }
    }
}
