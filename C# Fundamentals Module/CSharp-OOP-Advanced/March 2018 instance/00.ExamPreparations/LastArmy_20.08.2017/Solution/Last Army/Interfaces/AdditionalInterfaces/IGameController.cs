using System.Collections.Generic;

public interface IGameController
{
    void AddAmmuniotionCountToWareHouse(IEnumerable<string> args);

    string AddMission(IEnumerable<string> args);

    string AddSoldierToArmy(IEnumerable<string> args);

    void RegenerateSoldiers(IEnumerable<string> args);

    string RequestResults();
}