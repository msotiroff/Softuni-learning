using System;

public class TyreFactory
{
    public Tyre CreateInstance(params string[] commandArgs)
    {
        var tyreType = commandArgs[0];
        var tyreHardness = double.Parse(commandArgs[1]);

        Tyre tyre = null;
        switch (tyreType)
        {
            case DataConstants.UltrasoftTyreDefaultName:
                var grip = double.Parse(commandArgs[2]);
                tyre = new UltrasoftTyre(tyreHardness, grip);
                break;
            case DataConstants.HardTyreDefaultName:
                tyre = new HardTyre(tyreHardness);
                break;
            default:
                break;
        }

        return tyre ?? throw new ArgumentException(ErrorMessages.InvalidTyreType);
    }
}
