using System;

public class HarvestCommand : ICommand
{
    public string Execute()
    {
        Environment.Exit(0);

        return string.Empty;
    }
}
