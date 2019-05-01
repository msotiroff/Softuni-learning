﻿using System.Collections.Generic;

public interface IRaceTower
{
    int CurrentLap { get; }

    IDriver Winner { get; }

    void SetTrackInfo(int lapsNumber, int trackLength);

    void RegisterDriver(List<string> commandArgs);

    void DriverBoxes(List<string> commandArgs);

    string CompleteLaps(List<string> commandArgs);

    string GetLeaderboard();

    void ChangeWeather(List<string> commandArgs);
}