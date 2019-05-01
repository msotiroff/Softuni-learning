namespace Minedraft.Tests
{
    using NUnit.Framework;
    using System.Linq;

    [TestFixture]
    public class ProviderControllerTests
    {
        private IProviderController controller;

        [SetUp]
        public void InitializeRepository()
        {
            this.controller = new ProviderController(new EnergyRepository());
        }

        [Test]
        public void TestConstructorShouldWorkProperly()
        {
            Assert.That(() => typeof(IProviderController).IsAssignableFrom(this.controller.GetType()));
        }

        [TestCase("Pressure 40 100", "Successfully registered PressureProvider")]
        [TestCase("Solar 40 100", "Successfully registered SolarProvider")]
        [TestCase("Standart 40 100", "Successfully registered StandartProvider")]
        public void RegisterMethodShouldReturnCorrectValue(string input, string expected)
        {
            var arguments = input.Split().ToList();

            var actual = this.controller.Register(arguments);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        [TestCase("Pressure 40")]
        [TestCase("InvalidTypeProvider 40 100")]
        public void RegisterMethodShouldThrowException(string input)
        {
            Assert.That(() => 
            this.controller.Register(input.Split().ToList()), 
            Throws.Exception);
        }

        [Test]
        public void RegisterMethodShoudAddProviderToCollection()
        {
            var arguments = "Pressure 40 100".Split().ToList();

            this.controller.Register(arguments);
            this.controller.Register(arguments);
            this.controller.Register(arguments);

            var providerController = (ProviderController)this.controller;

            var actual = providerController.Entities.Count();

            var expected = 3;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, "Providers are repaired by 0")]
        [TestCase(20, "Providers are repaired by 20")]
        [TestCase(2000, "Providers are repaired by 2000")]
        public void RepairMethodShouldReturnCorrectValue(double value, string expected)
        {
            var actual = this.controller.Repair(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(30)]
        [TestCase(3000)]
        [TestCase(-130)]
        public void RepairMethodShouldIncreaseProvidersDurability(double value)
        {
            this.controller.Register("Pressure 1 1".Split().ToList());

            var providerConrtoller = (ProviderController)this.controller;

            var provider = providerConrtoller.Entities.First();

            var expected = provider.Durability + value;
            
            this.controller.Repair(value);

            var actual = provider.Durability;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(8, 2)]
        [TestCase(11, 1)]
        [TestCase(16, 0)]
        public void ProduceMethodShouldDeleteBrokenProviders(int countToInvokeMethod, int expectedAliveProviders)
        {
            this.controller.Register("Pressure 1 10".Split().ToList());
            this.controller.Register("Solar 2 10".Split().ToList());
            this.controller.Register("Standart 3 10".Split().ToList());

            for (int i = 0; i < countToInvokeMethod; i++)
            {
                this.controller.Produce();
            }

            var providerController = (ProviderController)this.controller;

            var actualAliveProviders = providerController.Entities.Count;

            Assert.AreEqual(expectedAliveProviders, actualAliveProviders);
        }

        [Test]
        public void ProduceMethodShouldReturnCorrectValue()
        {
            this.controller.Register("Standart 1 10".Split().ToList());
            this.controller.Register("Standart 2 10".Split().ToList());
            this.controller.Register("Standart 3 10".Split().ToList());

            var expected = string.Format(Constants.EnergyOutputToday, 30);

            var actual = this.controller.Produce();

            Assert.AreEqual(expected, actual);
        }
    }
}
