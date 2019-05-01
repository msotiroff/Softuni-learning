public class TyreFactory
{
    public static Tyre CreateInstance (params string[] args)
    {
        Tyre tyre = null;

        var tyreType = args[0];
        var tyreHardness = double.Parse(args[1]);
        double tyreGrip = 0.0;
        if (tyreType == "Ultrasoft")
        {
            tyreGrip = double.Parse(args[2]);
        }

        if (tyreType == "Ultrasoft")
        {
            tyre = new UltrasoftTyre(tyreHardness, tyreGrip);
        }
        else
        {
            tyre = new HardTyre(tyreHardness);
        }

        return tyre;
    }
}