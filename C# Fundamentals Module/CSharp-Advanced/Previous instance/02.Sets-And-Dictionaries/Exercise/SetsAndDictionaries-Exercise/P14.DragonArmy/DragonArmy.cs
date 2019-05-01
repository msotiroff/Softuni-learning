namespace P14.DragonArmy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DragonArmy
    {
        public static void Main(string[] args)
        {
            // <DragonType, Dragon>
            var allDragons = new Dictionary<string, List<Dragon>>();

            var inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                // Input format: {type} {name} {damage} {health} {armor}
                var inputParams = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var dragonType = inputParams[0];
                var dragonName = inputParams[1];

                int damage;
                if (!int.TryParse(inputParams[2], out damage))
                {
                    damage = 45;
                }

                int health;
                if (!int.TryParse(inputParams[3], out health))
                {
                    health = 250;
                }

                int armor;
                if (!int.TryParse(inputParams[4], out armor))
                {
                    armor = 10;
                }
                
                if (!allDragons.ContainsKey(dragonType))
                {
                    allDragons[dragonType] = new List<Dragon>();
                }

                var dragonToOverride = allDragons[dragonType].FirstOrDefault(d => d.Name == dragonName);

                if (dragonToOverride == null)
                {
                    var newDragon = new Dragon(dragonName, damage, health, armor);

                    allDragons[dragonType].Add(newDragon);
                }
                else
                {
                    dragonToOverride.Damage = damage;
                    dragonToOverride.Health = health;
                    dragonToOverride.Armor = armor;
                }
            }

            foreach (var type in allDragons)
            {
                var avgDamage = type.Value.Average(d => d.Damage);
                var avgHealth = type.Value.Average(d => d.Health);
                var avgArmor = type.Value.Average(d => d.Armor);

                Console.WriteLine($"{type.Key}::({avgDamage:f2}/{avgHealth:f2}/{avgArmor:f2})");

                foreach (var dragon in type.Value.OrderBy(d => d.Name))
                {
                    var name = dragon.Name;
                    var damage = dragon.Damage;
                    var health = dragon.Health;
                    var armor = dragon.Armor;

                    Console.WriteLine($"-{name} -> damage: {damage}, health: {health}, armor: {armor}");
                }
            }
        }
    }
}
