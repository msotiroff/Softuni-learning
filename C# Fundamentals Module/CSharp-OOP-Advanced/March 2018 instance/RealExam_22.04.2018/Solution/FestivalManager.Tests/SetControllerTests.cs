// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)
namespace FestivalManager.Tests
{
    using FestivalManager.Core.Controllers;
    using FestivalManager.Core.Controllers.Contracts;
    using FestivalManager.Entities;
    using FestivalManager.Entities.Contracts;
    using FestivalManager.Entities.Instruments;
    using FestivalManager.Entities.Sets;


    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
	public class SetControllerTests
    {
        private IStage stage;
        private SetController setController;

		[SetUp]
	    public void InitializeSetController()
        {
            this.stage = new Stage();
            this.setController = new SetController(stage);
        }

        [Test]
        public void PerformSetsShouldReturnSuccessMessage()
        {
            var song1 = new Song("Scorpions - You and I", new TimeSpan(0, 2, 0));
            var song2 = new Song("Scorpions - Always somewere", new TimeSpan(0, 1, 0));
            var song3 = new Song("Phill Collins - Money for nothing", new TimeSpan(0, 1, 0));
            var song4 = new Song("Ozzy Osbourne - If i close my eyes forever", new TimeSpan(0, 5, 0));

            var set = new Long("LongSet");
            set.AddSong(song1);
            set.AddSong(song2);
            set.AddSong(song3);
            set.AddSong(song4);

            var performer = new Performer("Pesho", 13);
            performer.AddInstrument(new Guitar());

            set.AddPerformer(performer);
            
            var stage = this.GetActualStage();
            stage.AddSet(set);

            var actual = this.setController.PerformSets();

            var isSuccessfull = actual.Contains("-- Set Successful");

            Assert.IsTrue(isSuccessfull);
        }

        [Test]
        public void PerformSetsShouldCallSetCanPerform()
        {
            var set1 = new Short("ShortSet");

            var stage = this.GetActualStage();
            stage.AddSet(set1);

            var actual = this.setController.PerformSets();

            var isNotPerformed = actual.Contains("-- Did not perform");

            Assert.IsTrue(isNotPerformed);
        }

        [Test]
        public void PerformSetsShouldNotSortSongs()
        {
            var song1 = new Song("Scorpions - You and I", new TimeSpan(0, 2, 0));
            var song2 = new Song("Scorpions - Always somewere", new TimeSpan(0, 1, 0));
            var song3 = new Song("Phill Collins - Money for nothing", new TimeSpan(0, 1, 0));
            var song4 = new Song("Ozzy Osbourne - If i close my eyes forever", new TimeSpan(0, 5, 0));
            
            var set = new Long("LongSet");
            set.AddSong(song1);
            set.AddSong(song2);
            set.AddSong(song3);
            set.AddSong(song4);

            var performer = new Performer("Pesho", 13);
            performer.AddInstrument(new Guitar());

            set.AddPerformer(performer);

            var expected1 = $"1. {song1.Name}";
            var expected2 = $"2. {song2.Name}";
            var expected3 = $"3. {song3.Name}";
            var expected4 = $"4. {song4.Name}";

            var stage = this.GetActualStage();
            stage.AddSet(set);

            var actual = this.setController.PerformSets();

            var songsAreUnsorted = actual.Contains(expected1) && actual.Contains(expected2) && actual.Contains(expected3) && actual.Contains(expected4);

            Assert.IsTrue(songsAreUnsorted);
        }

        [Test]
        public void PerformSetsShouldCallInstrumentsWearDown()
        {
            var performer = new Performer("Gosho", 20);
            var guitar = new Guitar();
            var guitarWearBefore = guitar.Wear;

            var song = new Song("Scorpions - You and I", new TimeSpan(0, 1, 0));

            performer.AddInstrument(guitar);

            var set1 = new Short("ShortSet");
            set1.AddSong(song);
            set1.AddPerformer(performer);

            var stage = this.GetActualStage();
            stage.AddSet(set1);

            this.setController.PerformSets();

            var guitarWearAfter = guitar.Wear;

            var isChanged = guitarWearAfter < guitarWearBefore;

            Assert.IsTrue(isChanged);
        }

        [Test]
        public void PerformSetsShouldOrderSetsCorrectly()
        {
            var set1 = new Short("ShortSet");
            set1.AddSong(new Song("Scorpions - You and I", new TimeSpan(0, 1, 0)));
            set1.AddSong(new Song("Scorpions - Always somewere", new TimeSpan(0, 2, 0)));
            set1.AddSong(new Song("Phill Collins - Money for nothing", new TimeSpan(0, 3, 0)));

            var set2 = new Medium("MediumSet");
            set2.AddSong(new Song("Scorpions - You and I", new TimeSpan(0, 1, 0)));
            set2.AddSong(new Song("Scorpions - Always somewere", new TimeSpan(0, 2, 0)));
            set2.AddSong(new Song("Phill Collins - Money for nothing", new TimeSpan(0, 3, 0)));
            set2.AddSong(new Song("Ozzy Osbourne - If i close my eyes forever", new TimeSpan(0, 5, 0)));

            var set3 = new Long("LongSet");
            set3.AddSong(new Song("Scorpions - You and I", new TimeSpan(0, 1, 0)));
            set3.AddSong(new Song("Scorpions - Always somewere", new TimeSpan(0, 2, 0)));
            set3.AddSong(new Song("Phill Collins - Money for nothing", new TimeSpan(0, 3, 0)));
            set3.AddSong(new Song("Ozzy Osbourne - If i close my eyes forever", new TimeSpan(0, 5, 0)));
            set3.AddPerformer(new Performer("Pesho", 20));
            
            var actualStage = this.GetActualStage();
            actualStage.AddSet(set1);
            actualStage.AddSet(set2);
            actualStage.AddSet(set3);

            var actual1 = $"1. {set3.Name}:";
            var actual2 = $"2. {set2.Name}:";
            var actual3 = $"3. {set1.Name}:";

            var result = this.setController.PerformSets();

            Assert.That(result.Contains(actual1));
            Assert.That(result.Contains(actual2));
            Assert.That(result.Contains(actual3));
        }
        
        [Test]
        public void ConstructorShouldSetTheGivenStage()
        {
            var stage = new Stage();

            stage.AddPerformer(new Performer("Gosho", 16));
            stage.AddPerformer(new Performer("Pesho", 16));
            stage.AddPerformer(new Performer("Misho", 33));
            stage.AddPerformer(new Performer("Dobri", 34));

            this.setController = new SetController(stage);

            var stagePerformersCount = this.GetActualStage().Performers.Count;

            Assert.AreEqual(4, stagePerformersCount);
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            var actualControllerStage = this.GetActualStage();

            Assert.IsNotNull(actualControllerStage);
        }

        private IStage GetActualStage()
        {
            var actualControllerStage = (IStage)typeof(SetController)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .FirstOrDefault(fi => fi.FieldType == typeof(IStage))
                .GetValue(this.setController);

            return actualControllerStage;
        }
    }
}