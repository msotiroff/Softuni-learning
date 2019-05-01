namespace Skeleton.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    [TestClass]
    public class AxeTests
    {
        private Axe brokenAxe;
        private Axe axe;
        private Dummy dummy;

        [TestInitialize]
        public void Initialize()
        {
            brokenAxe = new Axe(5, 0);
            axe = new Axe(10, 10);
            dummy = new Dummy(10, 10);
        }

        [TestMethod]
        public void AxeLosesDurabilityAfterAttack()
        {
            axe.Attack(dummy);

            Assert.AreEqual(this.axe.AttackPoints - 1, axe.DurabilityPoints, "Axe durability doesn't change after attack");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Axe is broken.")]
        public void AxeShouldNotBeAbleToAttackIfItIsBroken()
        {
            brokenAxe.Attack(dummy);
        }
    }
}