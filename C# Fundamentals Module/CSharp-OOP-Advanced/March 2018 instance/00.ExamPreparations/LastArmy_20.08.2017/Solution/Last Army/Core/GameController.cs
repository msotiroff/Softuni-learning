using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameController : IGameController
{
    private IMissionFactory missionFactory;
    private ISoldierFactory soldierFactory;
    private IWareHouse wareHouse;
    private IMissionController missionController;
    private IArmy army;

    public GameController(
        IMissionController missionController,
        IArmy army,
        IWareHouse wareHouse,
        ISoldierFactory soldierFactory,
        IMissionFactory missionFactory)
    {
        this.missionController = missionController;
        this.army = army;
        this.wareHouse = wareHouse;
        this.soldierFactory = soldierFactory;
        this.missionFactory = missionFactory;
    }

    public string AddSoldierToArmy(IEnumerable<string> args)
    {
        var parameters = args.ToArray();

        var type = parameters[0];
        var name = parameters[1];
        var age = int.Parse(parameters[2]);
        var experience = double.Parse(parameters[3]);
        var endurance = double.Parse(parameters[4]);

        var soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

        if (!this.wareHouse.TryEquipSoldier(soldier))
        {
            throw new System.ArgumentException(string.Format(OutputMessages.SoldierHasNotBeenCreated, type, name));
        }

        this.army.AddSoldier(soldier);

        return string.Empty;
    }

    public void AddAmmuniotionCountToWareHouse(IEnumerable<string> args)
    {
        // [Name] [Count]
        var parameters = args.ToArray();

        var ammunitionName = parameters[0];
        var ammunitionCount = int.Parse(parameters[1]);

        this.wareHouse.AddAmmunition(ammunitionName, ammunitionCount);
    }

    public string AddMission(IEnumerable<string> args)
    {
        var parameters = args.ToArray();

        var type = parameters[0];
        var scoreToComplete = double.Parse(parameters[1]);

        var mission = this.missionFactory.CreateMission(type, scoreToComplete);

        var result = this.missionController.PerformMission(mission).Trim();

        return result;
    }

    public void RegenerateSoldiers(IEnumerable<string> args)
    {
        var parameters = args.ToArray();

        var soldierType = parameters[1];

        this.army.RegenerateTeam(soldierType);
    }

    public string RequestResults()
    {
        this.missionController.FailMissionsOnHold();

        var builder = new StringBuilder()
            .AppendLine(OutputMessages.Results)
            .AppendLine(string.Format(OutputMessages.SuccessfullMissionsCount, this.missionController.SuccessMissionCounter))
            .AppendLine(string.Format(OutputMessages.FailedMissionsCount, this.missionController.FailedMissionCounter))
            .AppendLine(OutputMessages.Soldiers);

        foreach (var soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            builder.AppendLine(string.Format(OutputMessages.SoldierToString, soldier.Name, soldier.OverallSkill));
        }

        var result = builder.ToString().Trim();

        return result;
    }
}
