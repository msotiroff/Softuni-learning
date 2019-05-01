using System;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main(string[] args)
    {
        IDraftManager draftManager = new DraftManager();

        IEngine engine = new Engine(draftManager);

        engine.Run();
    }
}
