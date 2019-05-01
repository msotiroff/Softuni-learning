public abstract class MiningMachine
{
    protected MiningMachine(string id)
    {
        this.Id = id;
    }

    public string Id { get; private set; }
}
