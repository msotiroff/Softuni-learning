namespace Skeleton.Tests
{
    using NUnit.Framework;

    public class DummyTests
    {
        [Test]
        public void AliveDummyShouldNotGiveExperience()
        {
            var health = 5;
            var experience = 10;

            var dummy = new Dummy(health, experience);

            Assert.That(() => dummy.GiveExperience(), Throws.InvalidOperationException);
        }

        [TestCase(0, 10)]
        [TestCase(0, 20)]
        [TestCase(0, 100)]
        public void DeadDummyShouldGiveExperience(int health, int experience)
        {
            var dummy = new Dummy(health, experience);

            Assert.AreEqual(experience, dummy.GiveExperience());
        }

        [Test]
        public void DeadDummyShouldThrowExceptionIfAttacked()
        {
            var axeAttackPoints = 5;

            var dummyHealth = 5;
            var dummyExperience = 0;
            var dummy = new Dummy(dummyHealth, dummyExperience);

            dummy.TakeAttack(axeAttackPoints);

            Assert.That(() => dummy.TakeAttack(axeAttackPoints), 
                Throws.InvalidOperationException);
        }

        [Test]
        public void DummyShouldLoseHealthAfterAttack()
        {
            var axeAttackPoints = 5;

            var dummyHealth = 10;
            var dummyExperience = 0;
            var dummy = new Dummy(dummyHealth, dummyExperience);

            dummy.TakeAttack(axeAttackPoints);

            var expected = dummyHealth - axeAttackPoints;
            var actual = dummy.Health;

            Assert.AreEqual(expected, actual);
        }
    }
}
