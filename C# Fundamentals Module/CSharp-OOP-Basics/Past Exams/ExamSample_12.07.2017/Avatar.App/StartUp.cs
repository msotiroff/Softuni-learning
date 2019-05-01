public class StartUp
{
    public static void Main()
    {
        INationsBuilder nationsBuilder = new NationsBuilder();
        IEngine engine = new Engine(nationsBuilder);

        engine.Run();
    }
}