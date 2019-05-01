using System;
using System.Linq;
using System.Reflection;

public class HeroFactory : IHeroFactory
{
    public IHero CreateHero(string heroName, string heroType)
    {
        var type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.GetInterfaces()
                .Contains(typeof(IHero))
                && !t.IsAbstract)
            .FirstOrDefault(t => t.Name == heroType);

        // TODO: Throw if null

        var hero = Activator.CreateInstance(type, heroName);

        return (IHero)hero;
    }
}
