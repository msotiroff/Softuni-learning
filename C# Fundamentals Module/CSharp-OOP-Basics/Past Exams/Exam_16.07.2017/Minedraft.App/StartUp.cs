public class StartUp
{
    public static void Main(string[] args)
    {
        var draftManager = new DraftManager();

        var engine = new Engine(draftManager);

        engine.Run();
    }
}
