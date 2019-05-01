namespace RecyclingStation.WasteDisposal
{
    using System;
    using System.Linq;
    using System.Reflection;
    using RecyclingStation.Common;
    using RecyclingStation.Interfaces;
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;

    public class GarbageProcessor : IGarbageProcessor, IRequirementsHolder
    {
        private double minEnergyRequirement;
        private double minCapitalRequirement;
        private Type restrictedWaste;
        private IRepository recyclingStationRepository;

        public GarbageProcessor(IStrategyHolder strategyHolder, IRepository repository)
        {
            this.StrategyHolder = strategyHolder;
            this.recyclingStationRepository = repository;
            this.minEnergyRequirement = double.MinValue;
            this.minCapitalRequirement = double.MinValue;
        }
        
        public IStrategyHolder StrategyHolder { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            Type garbageType = garbage.GetType();

            var isDenied = (this.recyclingStationRepository.EnergyBalance < this.minEnergyRequirement
                || this.recyclingStationRepository.CapitalBalance < this.minCapitalRequirement)
                && this.restrictedWaste == garbageType;

            if (isDenied)
            {
                throw new InvalidOperationException(Constants.ProcessDenied);
            }

            DisposableAttribute disposalAttribute = (DisposableAttribute)garbageType
                .GetCustomAttributes(false)
                .FirstOrDefault(x => x.GetType()
                    .IsSubclassOf(typeof(DisposableAttribute)));

            var strategyType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetInterfaces()
                    .Contains(typeof(IGarbageDisposalStrategy)))
                .Where(t => t.GetCustomAttribute<DisposableAttribute>() != null)
                .FirstOrDefault(t => t.GetCustomAttribute<DisposableAttribute>().GetType() == disposalAttribute.GetType());
                
            if (disposalAttribute == null || strategyType == null)
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            var disposalAttributeInheritorType = disposalAttribute.GetType();

            if (!this.StrategyHolder.GetDisposalStrategies.ContainsKey(disposalAttributeInheritorType))
            {
                var currentStrategy = (IGarbageDisposalStrategy)Activator.CreateInstance(strategyType, new object[] { });

                this.StrategyHolder.AddStrategy(disposalAttributeInheritorType, currentStrategy);
            }

            var neededStrategy = this.StrategyHolder.GetDisposalStrategies[disposalAttributeInheritorType];
            
            var processingData = neededStrategy.ProcessGarbage(garbage);
            
            return processingData;
        }

        public void ChangeRequirements(Type restrictedWasteType, double newEnergyRequirement, double newCapitalRequirement)
        {
            this.minEnergyRequirement = newEnergyRequirement;
            this.minCapitalRequirement = newCapitalRequirement;
            this.restrictedWaste = restrictedWasteType;
        }
    }
}
