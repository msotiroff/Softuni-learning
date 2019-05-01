﻿using System.Collections.Generic;
using System.Linq;

public class Army : IArmy
{
    private List<ISoldier> soldiers;

    public Army()
    {
        this.soldiers = new List<ISoldier>();
    }

    public IReadOnlyList<ISoldier> Soldiers => this.soldiers;

    public void AddSoldier(ISoldier soldier)
    {
        this.soldiers.Add(soldier);
    }

    public void RegenerateTeam(string soldierType)
    {
        var teamToBeRegenerated = this.soldiers.Where(s => s.GetType().Name == soldierType).ToList();

        teamToBeRegenerated
            .ForEach(s => s.Regenerate());
    }
}
