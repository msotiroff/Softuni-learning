using NUnit.Framework;

[TestFixture]
public class MissionControllerTests
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController controller;

    [SetUp]
    public void InitializeController()
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.controller = new MissionController(this.army, this.wareHouse);
    }

    [Test]
    public void PerformMissionMethodShouldIncreaseFailedMissionsCounter()
    {
        this.controller.PerformMission(new Easy(100));
        this.controller.PerformMission(new Easy(100));
        this.controller.PerformMission(new Easy(100));
        this.controller.PerformMission(new Easy(100));

        Assert.AreEqual(1, this.controller.FailedMissionCounter);
    }

    [Test]
    public void PerformMissionMethodShouldReturnCorrectValueWhenMissionDeclined()
    {
        this.controller.PerformMission(new Easy(100));
        this.controller.PerformMission(new Easy(100));
        this.controller.PerformMission(new Easy(100));
        var actual = this.controller.PerformMission(new Easy(100)).Trim();
        var expected = "Mission declined - Suppression of civil rebellion\r\nMission on hold - Suppression of civil rebellion\r\nMission on hold - Suppression of civil rebellion\r\nMission on hold - Suppression of civil rebellion";

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void PerformMissionMethodShouldIncreaseSuccessfulMissionsCounter()
    {
        var soldier = new Ranker("Spartacus", 26, 100, 300);

        this.wareHouse.AddAmmunition(nameof(Gun), 10);
        this.wareHouse.AddAmmunition(nameof(AutomaticMachine), 10);
        this.wareHouse.AddAmmunition(nameof(Helmet), 10);

        this.army.AddSoldier(soldier);
        this.controller.PerformMission(new Easy(20));

        var actual = this.controller.SuccessMissionCounter;

        Assert.AreEqual(1, actual);
    }

    [Test]
    public void PerformMissionMethodShouldReturnCorrectValueWhenMissionSuccessful()
    {
        var soldier = new Ranker("Spartacus", 26, 100, 300);

        this.wareHouse.AddAmmunition(nameof(Gun), 10);
        this.wareHouse.AddAmmunition(nameof(AutomaticMachine), 10);
        this.wareHouse.AddAmmunition(nameof(Helmet), 10);

        this.army.AddSoldier(soldier);

        var currentMission = new Easy(20);

        var actual = this.controller.PerformMission(currentMission).TrimEnd();

        var expected = string.Format(OutputMessages.MissionSuccessful, currentMission.Name);

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void PerformMissionMethodShouldReturnCorrectValueWhenMissionFailed()
    {
        var soldier = new Ranker("Spartacus", 26, 100, 300);

        this.wareHouse.AddAmmunition(nameof(Gun), 10);
        this.wareHouse.AddAmmunition(nameof(AutomaticMachine), 10);
        this.wareHouse.AddAmmunition(nameof(Helmet), 10);

        this.army.AddSoldier(soldier);

        var currentMission = new Easy(200);

        var actual = this.controller.PerformMission(currentMission).TrimEnd();

        var expected = string.Format(OutputMessages.MissionOnHold, currentMission.Name);

        Assert.AreEqual(expected, actual);
    }
}
