public abstract class Monument
{
    protected Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get; private set; }

    public abstract int GetAffinity();

    public override string ToString()
    {
        var monumentTypeName = this.GetType().Name.Replace("Monument", string.Empty);

        return $"{monumentTypeName} Monument: {this.Name}, {monumentTypeName} Affinity: {this.GetAffinity()}";
    }
}
