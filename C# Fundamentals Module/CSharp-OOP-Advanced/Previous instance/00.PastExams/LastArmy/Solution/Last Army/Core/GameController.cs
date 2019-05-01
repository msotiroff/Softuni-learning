using System;
using System.Linq;
using System.Text;

public class GameController : IGameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private IMissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;

    public GameController(
        IMissionController missionController,
        ISoldierFactory soldierFactory,
        IMissionFactory missionFactory,
        IArmy army,
        IWareHouse wareHouse)
    {
        this.missionController = missionController;
        this.soldierFactory = soldierFactory;
        this.missionFactory = missionFactory;
        this.army = army;
        this.wareHouse = wareHouse;
    }

    public string AddAmmunitionsToWarehouse(string name, int count)
    {
        this.wareHouse.AddAmmunitions(name, count);

        return string.Empty;
    }

    public string AddMission(string type, double scoreToComplete)
    {
        var mission = this.missionFactory.CreateMission(type, scoreToComplete);

        return this.missionController.PerformMission(mission);
    }

    public string AddSoldierToArmy(string soldierType, string soldierName, int age, double experience, double endurance)
    {
        var soldier = this.soldierFactory.CreateSoldier(soldierType, soldierName, age, experience, endurance);

        if (!this.wareHouse.TryToEquipSoldier(soldier))
        {
            return string.Format(OutputMessages.NoWeaponsForSoldierType, soldierType, soldierName);
        }

        this.army.AddSoldier(soldier);

        return string.Empty;
    }

    public string RegenerateSoldiers(string soldierType)
    {
        this.army.RegenerateTeam(soldierType);

        return string.Empty;
    }

    public string RequestResults()
    {
        var builder = new StringBuilder();

        var orderedSoldiers = this.army
            .Soldiers
            .OrderByDescending(s => s.OverallSkill)
            .ToList();

        this.missionController.FailMissionsOnHold();

        builder.AppendLine("Results:");
        builder.AppendLine(string.Format(OutputMessages.MissionsSummurySuccessful, this.missionController.SuccessMissionCounter));
        builder.AppendLine(string.Format(OutputMessages.MissionsSummuryFailed, this.missionController.FailedMissionCounter));
        builder.AppendLine("Soldiers:");
        builder.AppendLine(string.Join(Environment.NewLine, orderedSoldiers));

        var result = builder.ToString().TrimEnd();

        return result;
    }
}