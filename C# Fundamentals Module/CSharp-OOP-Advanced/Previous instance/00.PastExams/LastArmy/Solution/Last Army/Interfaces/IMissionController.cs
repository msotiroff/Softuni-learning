using System.Collections.Generic;

public interface IMissionController
{
    Queue<IMission> Missions { get; }

    int SuccessMissionCounter { get; }

    int FailedMissionCounter { get; }

    void FailMissionsOnHold();

    string PerformMission(IMission mission);
}
