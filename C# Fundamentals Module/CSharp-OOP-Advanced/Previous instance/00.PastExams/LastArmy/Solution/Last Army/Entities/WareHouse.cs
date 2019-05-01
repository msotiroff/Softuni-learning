using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IAmmunitionFactory ammunitionFactory;
    private IDictionary<string, int> ammunitionQuantities;

    public WareHouse(IAmmunitionFactory ammunitionFactory)
    {
        this.ammunitionFactory = ammunitionFactory;
        this.ammunitionQuantities = new Dictionary<string, int>();
    }

    public void AddAmmunitions(string name, int count)
    {
        if (!this.ammunitionQuantities.ContainsKey(name))
        {
            this.ammunitionQuantities[name] = 0;
        }

        this.ammunitionQuantities[name] += count;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryToEquipSoldier(soldier);
        }
    }

    public bool TryToEquipSoldier(ISoldier soldier)
    {
        var isEquipped = true;

        var neededWeapons = soldier
            .Weapons
            .Where(w => w.Value == null)
            .Select(w => w.Key)
            .ToArray();

        for (int i = 0; i < neededWeapons.Length; i++)
        {
            var weapon = neededWeapons[i];

            if (this.ammunitionQuantities.ContainsKey(weapon) && ammunitionQuantities[weapon] > 0)
            {
                soldier.Weapons[weapon] = this.ammunitionFactory.CreateAmmunition(weapon);
                this.ammunitionQuantities[weapon]--;
            }
            else
            {
                isEquipped = false;
            }
        }

        return isEquipped;
    }
}
