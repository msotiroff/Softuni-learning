using RecyclingStation.Extensions.CustomAttributes;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Models.Strategies
{
    [Recyclable]
    public class RecyclableStrategy : IGarbageDisposalStrategy
    {
        public IProcessingData ProcessGarbage(IWaste garbage)
        {
            var energyProduced = 0;
            var energyUsed = garbage.Weight * garbage.VolumePerKg / 2;
            var energy = energyProduced - energyUsed;

            var capitalEarned = 400 * garbage.Weight;
            var capitalUsed = 0;
            var capital = capitalEarned - capitalUsed;

            var processingData = new ProcessingData(energy, capital);

            return processingData;
        }
    }
}
