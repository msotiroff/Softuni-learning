namespace Skeleton.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class DummyTests
    {
        private Axe axe;
        private Dummy deadDummy;
        private Dummy aliveDummy;


        [TestInitialize]
        public void Initialize()
        {
            aliveDummy = new Dummy(5, 10);
            deadDummy = new Dummy(0, 10);
            axe = new Axe(4, 10);
        }

        [TestMethod]
        public void DummyLosesHealthIfAttacked()
        {
            aliveDummy.TakeAttack(axe.AttackPoints);

            Assert.AreEqual(1, aliveDummy.Health, "Does not decrease health correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Dummy is dead.")]
        public void DummyShouldThrowAnExceptionIfAttackedWhenDead()
        {
            deadDummy.TakeAttack(axe.AttackPoints);
        }

        [TestMethod]
        public void DeadDummyShouldGiveExperience()
        {
            var experience = deadDummy.GiveExperience();

            Assert.AreEqual(experience, 10, "Dead dummy does not give experience");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Target is not dead.")]
        public void AliveDummySouldNotGiveExperience()
        {
            var experience = aliveDummy.GiveExperience();
        }
    }
}
