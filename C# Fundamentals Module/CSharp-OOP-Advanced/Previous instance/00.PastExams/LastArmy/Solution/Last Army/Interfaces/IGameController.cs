public interface IGameController
{
    string RequestResults();

    string RegenerateSoldiers(string soldierType);

    string AddSoldierToArmy(string soldierType, string soldierName, int age, double experience, double endurance);

    string AddAmmunitionsToWarehouse(string name, int count);

    string AddMission(string type, double scoreToComplete);
}
