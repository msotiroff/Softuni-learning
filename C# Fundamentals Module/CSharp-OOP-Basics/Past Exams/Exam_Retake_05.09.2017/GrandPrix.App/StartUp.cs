public class StartUp
{
    public static void Main(string[] args)
    {
        IRaceTower raceTower = new RaceTower();
        IEngine engine = new Engine(raceTower);

        engine.Run();
    }
}