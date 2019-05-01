public class StartUp
{
    public static void Main()
    {
        var carManager = new CarManager();
        var engine = new Engine(carManager);

        engine.Run();
    }
}
