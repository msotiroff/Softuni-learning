namespace Skeleton.Tests
{
    using NUnit.Framework;

    public class AxeTests
    {
        [Test]
        public void WeaponShouldLoseDurabilityAfterAttack()
        {
            var initialDurability = 20;
            var tokenPoints = 1;
            var attackPoints = 10;

            var health = 10;
            var experience = 0;

            var axe = new Axe(attackPoints, initialDurability);
            var dummy = new Dummy(health, experience);

            axe.Attack(dummy);

            var expected = initialDurability - tokenPoints;
            var actual = axe.DurabilityPoints;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AttackWithBrokenAxeShouldThrowException()
        {
            var durability = 1;
            var attackPoints = 10;

            var health = 10;
            var experience = 0;

            var axe = new Axe(attackPoints, durability);
            var dummy = new Dummy(health, experience);

            axe.Attack(dummy);

            Assert.That(() => axe.Attack(dummy), Throws.InvalidOperationException);
        }
    }
}
