using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private IDictionary<string, int> allWeapons;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse(IAmmunitionFactory ammunitionFactory)
    {
        this.ammunitionFactory = ammunitionFactory;
        this.allWeapons = new Dictionary<string, int>();
    }

    public WareHouse()
    {
        this.ammunitionFactory = new AmmunitionFactory();
        this.allWeapons = new Dictionary<string, int>();
    }

    public void AddAmmunition(string ammunitionName, int ammunitionCount)
    {
        if (!this.allWeapons.ContainsKey(ammunitionName))
        {
            this.allWeapons[ammunitionName] = 0;
        }

        this.allWeapons[ammunitionName] += ammunitionCount;
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
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

            if (this.allWeapons.ContainsKey(weapon) && allWeapons[weapon] > 0)
            {
                soldier.Weapons[weapon] = this.ammunitionFactory.CreateAmmunition(weapon);
                this.allWeapons[weapon]--;
            }
            else
            {
                isEquipped = false;
            }
        }

        return isEquipped;
    }
}
