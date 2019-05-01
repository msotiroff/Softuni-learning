public class StartUp
{
    public static void Main()
    {
        var spy = new Spy();

        var result = spy.StealFieldInfo("Hacker", "username", "password");

        System.Console.WriteLine(result);
    }
}
