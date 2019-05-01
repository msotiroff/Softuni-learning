﻿using System.Collections.Generic;

public interface INationsBuilder
{
    void AssignBender(List<string> benderArgs);

    void AssignMonument(List<string> monumentArgs);

    string GetStatus(string nationsType);

    void IssueWar(string nationsType);

    string GetWarsRecord();
}
