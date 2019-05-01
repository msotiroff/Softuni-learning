using RecyclingStation.Core;
using RecyclingStation.Interfaces;
using RecyclingStation.IO;
using RecyclingStation.Models;
using RecyclingStation.Models.Waste.Factory;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation
{
    public class RecyclingStationMain
    {
        private static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IWasteFactory wasteFactory = new WasteFactory();
            IRepository repository = new RecyclingStationRepository();
            
            IStrategyHolder strategyHolder = new StrategyHolder();
            IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder, repository);
            IWasteProcessingManager processingManager = new WasteProcessingManager(garbageProcessor);

            IWasteProcessingManager wasteManager = new WasteProcessingManager(garbageProcessor);

            IEngine engine = new Engine(reader, writer, wasteFactory, garbageProcessor, repository, wasteManager);
            engine.Run();
        }
    }
}
