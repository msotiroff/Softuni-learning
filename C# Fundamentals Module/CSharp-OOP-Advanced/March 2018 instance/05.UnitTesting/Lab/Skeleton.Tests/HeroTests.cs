namespace Skeleton.Tests
{
    using NUnit.Framework;
    using Moq;

    public class HeroTests
    {
        [Test]
        public void HeroShouldGainExperienceWhenTargetDies()
        {
            var weaponAttackPoints = 10;

            var targetHealth = 3;
            var targetExperiennce = 15;

            var heroName = "Asterix";

            var weapon = new Mock<IWeapon>();
            weapon.Setup(w => w.AttackPoints).Returns(weaponAttackPoints);

            var target = new Mock<ITarget>();
            target.Setup(t => t.Health).Returns(targetHealth);
            target.Setup(t => t.GiveExperience()).Returns(targetExperiennce);
            target.Setup(t => t.IsDead()).Returns(true);

            var hero = new Hero(heroName, weapon.Object);
            
            hero.Attack(target.Object);

            Assert.AreEqual(targetExperiennce, hero.Experience);
        }
    }
}
