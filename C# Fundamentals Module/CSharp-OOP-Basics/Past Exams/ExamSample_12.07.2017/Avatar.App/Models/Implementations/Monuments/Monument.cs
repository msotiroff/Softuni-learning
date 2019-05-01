public abstract class Monument : IMonument
{
    private string name;

    public string Name
    {
        get => this.name;
        private set
        {
            this.name = value;
        }
    }

    public Monument(string name)
    {
        this.Name = name;
    }

    public abstract double GetAffinity();
}
