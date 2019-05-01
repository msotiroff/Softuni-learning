namespace RecyclingStation.Tests
{
    using Moq;
    using NUnit.Framework;
    using RecyclingStation.Common;
    using RecyclingStation.Extensions.CustomAttributes;
    using RecyclingStation.Interfaces;
    using RecyclingStation.Models.Strategies;
    using RecyclingStation.Models.Waste;
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class GarbageProcessorTests
    {
        private IGarbageProcessor garbageProcessor;
        private Mock<IStrategyHolder> strategyHolder;
        private Mock<IRepository> repository;

        [SetUp]
        public void InitializeProcessor()
        {
            this.repository = new Mock<IRepository>();
            this.strategyHolder = new Mock<IStrategyHolder>();
            this.strategyHolder.Setup(sh => sh.GetDisposalStrategies).Returns(new Dictionary<Type, IGarbageDisposalStrategy>());
            this.garbageProcessor = new GarbageProcessor(this.strategyHolder.Object, this.repository.Object);
        }

        [Test]
        public void ConstructorShouldSetRequrementFieldsToDoubleMinValue()
        {
            var requirementsFields = typeof(GarbageProcessor)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(fi => fi.FieldType == typeof(double))
                .Select(f => f.GetValue(this.garbageProcessor).ToString())
                .ToArray();

            Assert.IsTrue(requirementsFields.All(v => v == double.MinValue.ToString()));
        }

        [Test]
        public void ProcessWasteMethodShouldReturnCorrectProcessingData()
        {
            IWaste garbage = new BurnableGarbage("Waste Veggy Oil", 10, 10);
            var dictionaty = new Dictionary<Type, IGarbageDisposalStrategy>()
            {
                [typeof(BurnableAttribute)] = new BurnableStrategy()
            };

            this.strategyHolder.Setup(sh => sh.GetDisposalStrategies).Returns(dictionaty);

            var processingData = this.garbageProcessor.ProcessWaste(garbage);

            Assert.AreEqual(80, processingData.EnergyBalance);
            Assert.AreEqual(0, processingData.CapitalBalance);
        }

        [Test]
        public void ChangeRequirementsMethodShouldSetRestrictedType()
        {
            var requirementHolder = (IRequirementsHolder)this.garbageProcessor;

            requirementHolder.ChangeRequirements(typeof(BurnableGarbage), 100, 100);

            var restrictedType = typeof(GarbageProcessor)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(f => f.FieldType == typeof(Type))
                .GetValue(requirementHolder);

            Assert.AreEqual(typeof(BurnableGarbage), restrictedType);
        }

        [TestCase(100.13)]
        [TestCase(-147.258963)]
        [TestCase(2_000_000_000)]
        public void ChangeRequirementsMethodShouldSetMinimumRequrements(double newValue)
        {
            var requirementHolder = (IRequirementsHolder)this.garbageProcessor;

            requirementHolder.ChangeRequirements(typeof(StorableGarbage), newValue, newValue);

            var requirementsFields = typeof(GarbageProcessor)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(fi => fi.FieldType == typeof(double))
                .Select(f => f.GetValue(this.garbageProcessor))
                .Select(v => double.Parse(v.ToString()))
                .ToArray();

            Assert.IsTrue(requirementsFields.All(v => v == newValue));
        }
    }
}
