public class Startup
{
    public static void Main()
    {
        var nationsBuilder = new NationsBuilder();
        var engine = new Engine(nationsBuilder);

        engine.Run();
    }
}
