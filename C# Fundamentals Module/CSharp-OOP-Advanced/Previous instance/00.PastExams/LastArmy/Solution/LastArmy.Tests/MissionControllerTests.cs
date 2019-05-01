namespace LastArmy.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class MissionControllerTests
    {
        private MissionController missionController;

        [SetUp]
        public void InitializeMissionController()
        {
            this.missionController = new MissionController(
                    new Army(), 
                    new WareHouse(new AmmunitionFactory()));
        }

        [TestCase(typeof(Easy), "Mission on hold - Suppression of civil rebellion")]
        [TestCase(typeof(Medium), "Mission on hold - Capturing dangerous criminals")]
        [TestCase(typeof(Hard), "Mission on hold - Disposal of terrorists")]
        public void PerformMissionMethodShouldReturnCorrectString(Type missionType, string expected)
        {
            IMission mission = (IMission)Activator.CreateInstance(missionType, new object[] { 10 });

            var actual = this.missionController.PerformMission(mission).TrimEnd();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EasyMissionShouldBeCompleted()
        {
            Ranker ranker = new Ranker("Pesho", 25, 100, 1000);
            ranker.Weapons[nameof(Gun)] = new Gun("Gun");
            ranker.Weapons[nameof(AutomaticMachine)] = new AutomaticMachine("AutomaticMachine");
            ranker.Weapons[nameof(Helmet)] = new Helmet("Helmet");

            Army army = new Army();
            army.AddSoldier(ranker);

            this.missionController = new MissionController(army, new WareHouse(new AmmunitionFactory()));
            IMission mission = new Easy(20);

            var actual = this.missionController.PerformMission(mission);
            var expected = "Mission completed - Suppression of civil rebellion";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MediumMissionShouldBeCompleted()
        {
            Ranker ranker = new Ranker("Pesho", 25, 100, 1000);
            ranker.Weapons[nameof(Gun)] = new Gun("Gun");
            ranker.Weapons[nameof(AutomaticMachine)] = new AutomaticMachine("AutomaticMachine");
            ranker.Weapons[nameof(Helmet)] = new Helmet("Helmet");

            Army army = new Army();
            army.AddSoldier(ranker);

            this.missionController = new MissionController(army, new WareHouse(new AmmunitionFactory()));
            IMission mission = new Medium(10);

            var actual = this.missionController.PerformMission(mission);
            var expected = "Mission completed - Capturing dangerous criminals";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HardMissionShouldBeCompleted()
        {
            Ranker ranker = new Ranker("Pesho", 25, 100, 1000);
            ranker.Weapons[nameof(Gun)] = new Gun("Gun");
            ranker.Weapons[nameof(AutomaticMachine)] = new AutomaticMachine("AutomaticMachine");
            ranker.Weapons[nameof(Helmet)] = new Helmet("Helmet");

            Army army = new Army();
            army.AddSoldier(ranker);

            this.missionController = new MissionController(army, new WareHouse(new AmmunitionFactory()));
            IMission mission = new Hard(10);

            var actual = this.missionController.PerformMission(mission);
            var expected = "Mission completed - Disposal of terrorists";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeciningOlderMissionsInQueue()
        {
            IMission missionOne = new Easy(10);
            IMission missionTwo = new Easy(10);
            IMission missionThree = new Easy(10);
            IMission missionFour = new Easy(10);

            this.missionController.Missions.Enqueue(missionOne);
            this.missionController.Missions.Enqueue(missionTwo);
            this.missionController.Missions.Enqueue(missionThree);

            var expected = "Mission declined - Suppression of civil rebellion" +
                Environment.NewLine +
                "Mission on hold - Suppression of civil rebellion" +
                Environment.NewLine +
                "Mission on hold - Suppression of civil rebellion" +
                Environment.NewLine +
                "Mission on hold - Suppression of civil rebellion";

            var actual = this.missionController.PerformMission(missionFour);

            Assert.AreEqual(expected, actual);
        }
    }
}
