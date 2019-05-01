namespace RecyclingStation.Tests
{
    using NUnit.Framework;
    using Moq;
    using RecyclingStation.WasteDisposal.Interfaces;
    using RecyclingStation.WasteDisposal;
    using RecyclingStation.Extensions.CustomAttributes;
    using RecyclingStation.Models.Strategies;
    using System;
    using RecyclingStation.WasteDisposal.Attributes;
    using System.Collections.Generic;

    [TestFixture]
    public class StrategyHolderTests
    {
        private IStrategyHolder strategyHolder;

        [SetUp]
        public void InitializeStrategyHolder()
        {
            this.strategyHolder = new StrategyHolder();
        }

        [Test]
        public void ConstructorShouldInitializeInnerCollection()
        {
            var collection = this.strategyHolder.GetDisposalStrategies;

            Assert.AreEqual(collection.Count, 0);
        }

        [Test]
        public void AddMethodShouldFillInnerCollection()
        {
            var attributeType = typeof(StorableAttribute);
            var strategy = new StorableStrategy();

            this.strategyHolder.AddStrategy(attributeType, strategy);


            var actual = this.strategyHolder.GetDisposalStrategies.Count;

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfAttributeIsNotDisposalAttribute()
        {
            var attribute = typeof(Attribute);
            var strategy = new RecyclableStrategy();

            Assert.That(() => 
                this.strategyHolder.AddStrategy(attribute, strategy), 
                Throws.ArgumentException);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfAttributeIsAbstract()
        {
            var attribute = typeof(DisposableAttribute);
            var strategy = new RecyclableStrategy();

            Assert.That(() =>
                this.strategyHolder.AddStrategy(attribute, strategy),
                Throws.ArgumentException);
        }

        [Test]
        public void AddMethodShouldReturnFalseIfAlreadyHasThisStrategy()
        {
            var attributeType = typeof(StorableAttribute);
            var strategy = new StorableStrategy();

            this.strategyHolder.AddStrategy(attributeType, strategy);

            Assert.IsFalse(this.strategyHolder.AddStrategy(attributeType, strategy));
        }

        [Test]
        public void AddMethodShouldReturnTrueIfDoesNotHaveThisStrategy()
        {
            var attributeType = typeof(StorableAttribute);
            var strategy = new StorableStrategy();
            
            Assert.IsTrue(this.strategyHolder.AddStrategy(attributeType, strategy));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfAttributeIsNotDisposal()
        {
            var attribute = typeof(Attribute);

            Assert.That(() => 
                this.strategyHolder.RemoveStrategy(attribute), 
                Throws.ArgumentException);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfAttributeIsAbstractl()
        {
            var attribute = typeof(DisposableAttribute);

            Assert.That(() =>
                this.strategyHolder.RemoveStrategy(attribute),
                Throws.ArgumentException);
        }

        [TestCase(typeof(StorableAttribute))]
        [TestCase(typeof(RecyclableAttribute))]
        [TestCase(typeof(BurnableAttribute))]
        public void RemoveMethodShouldReturnFalseIfDoesNotContainAttributeType(Type attributeType)
        {
            Assert.IsFalse(this.strategyHolder.RemoveStrategy(attributeType));
        }

        [Test]
        public void RemoveMethodShouldReturnTrueIfHasAttributeType()
        {
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableStrategy());

            Assert.IsTrue(this.strategyHolder.RemoveStrategy(typeof(BurnableAttribute)));
        }

        [Test]
        public void RemoveMethodShouldDeleteEntryFromInnerCollection()
        {
            this.strategyHolder.AddStrategy(typeof(StorableAttribute), new StorableStrategy());
            this.strategyHolder.AddStrategy(typeof(BurnableAttribute), new BurnableStrategy());
            this.strategyHolder.AddStrategy(typeof(RecyclableAttribute), new RecyclableStrategy());

            this.strategyHolder.RemoveStrategy(typeof(BurnableAttribute));

            var contains = this.strategyHolder.GetDisposalStrategies.ContainsKey(typeof(BurnableAttribute));

            Assert.IsFalse(contains);
        }
    }
}
