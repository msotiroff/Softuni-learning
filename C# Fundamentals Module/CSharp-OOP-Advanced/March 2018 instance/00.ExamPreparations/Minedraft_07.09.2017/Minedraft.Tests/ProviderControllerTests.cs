using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ProviderControllerTests
{
    private IEnergyRepository energyRepository;
    private ProviderController providerController;

    [SetUp]
    public void InitializeController()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void ProduceShouldRemoveBrokenProvider()
    {
        var providerArgs = new List<string>() { "Standart", "1", "100" };

        this.providerController.Register(providerArgs);

        for (int i = 0; i < 11; i++)
        {
            this.providerController.Produce();
        }

        Assert.AreEqual(this.providerController.Entities.Count, 0);
    }

    [Test]
    public void ProduceShouldIncreaseEnergyInRepository()
    {
        var providerArgs = new List<string>() { "Standart", "1", "100" };

        this.providerController.Register(providerArgs);

        this.providerController.Produce();

        Assert.AreEqual(this.energyRepository.EnergyStored, 100);
    }

    [Test]
    public void RepairShouldIncreaseProvidersDurability()
    {
        var providerArgs = new List<string>() { "Standart", "1", "100" };

        this.providerController.Register(providerArgs);

        var provider = this.providerController.Entities.First();

        Assert.AreEqual(provider.Durability, 1000);

        this.providerController.Repair(500);

        Assert.AreEqual(provider.Durability, 1500);
    }

    [Test]
    public void RegisterShouldAddNewProviderToCollection()
    {
        var providerArgs = new List<string>() { "Standart", "1", "100" };

        this.providerController.Register(providerArgs);

        var actual = this.providerController.Entities.Count;

        Assert.AreEqual(1, actual);
    }
}