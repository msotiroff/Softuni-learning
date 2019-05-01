public class Driver : IDriver
{
    public string Name { get; private set; }

    public Driver(string name)
    {
        this.Name = name;
    }
}
